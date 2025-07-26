using Gronio.Api.ResponseWrapper;
using Gronio.Database.Abstraction;
using Gronio.Database.EntityFramework.PostgreSql;
using Gronio.Utility.Helper.Core.ConfigurationHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;
using System.Text.Json;
using TicketSystem.Business.ServiceRegistration;
using TicketSystem.Common.Models.Configurations;
using TicketSystem.DataAccess.Context;
using TicketSystem.DataAccess.ServiceRegistration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.BindConfigurationsWithConsul("Consul:ConsulConfigKey", "Consul:Host", "Consul:Token");

builder.Services.Configure<AppSettingConfiguration>(builder.Configuration);

builder.Services
    .AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidAudience = builder.Configuration["JwtSettings:Audience"],
                ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]))
            };
        });

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddAuthorizationCore();

builder.Services.AddControllers(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy));

}).AddJsonOptions(o =>
{
    o.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    o.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    o.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    o.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddResponseCompression(opt =>
{
    opt.Providers.Add<BrotliCompressionProvider>();
    opt.Providers.Add<GzipCompressionProvider>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDatabase(opt =>
{
    opt.SetDatabaseId(builder.Configuration.GetSection("DatabaseDefinitions:DbId").Get<string>());
    opt.UsePostgreSql<TicketAutomationSystemDbContext>(builder.Configuration.GetConnectionString("TicketAutomationSystem"), null, null);
}, ServiceLifetime.Scoped);

builder.Services.AddHttpClient();

builder.Services.AddOpenApi();

builder.Services.AddBusinessServices(ServiceLifetime.Scoped);
builder.Services.AddDataAccessServices(ServiceLifetime.Scoped);
 
var app = builder.Build();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto | ForwardedHeaders.XForwardedHost,
});

app.UseAuthentication();
app.UseAuthorization();

app.MapOpenApi();

app.MapScalarApiReference(opt =>
{
    opt.WithTitle(builder.Configuration.GetSection("Swagger:Title").Get<string>())
        .WithTheme(ScalarTheme.BluePlanet)
        .WithDotNetFlag()
        .WithDynamicBaseServerUrl(true)
        .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.Curl);
});

app.UseResponseWrapper(opt =>
{
    opt.ExceptEndpoints("/", "/health/ready", "/health/live", "/swagger", "/scalar", "openapi/v1.json");
    opt.HideApiVersionInModel();
    opt.HideApiVersionInResponseHeader();
});

app.UseCors(opt =>
{
    opt.AllowAnyOrigin();
    opt.AllowAnyHeader();
    opt.AllowAnyMethod();
});

app.UseHealthChecks("/health/ready", new HealthCheckOptions
{
    ResponseWriter = async (c, r) =>
    {
        c.Response.ContentType = "application/json";

        var result = JsonSerializer.Serialize(new
        {
            Status = r.Status.ToString(),
            StatusId = (short)r.Status,
            Components = r.Entries.Select(e => new
            { Service = e.Key, Status = e.Value.Status.ToString(), StatusId = e.Value.Status }).ToArray(),
        });

        await c.Response.WriteAsync(result).ConfigureAwait(false);
    },
});

app.UseHealthChecks("/health/live");
 
app.MapControllers();

await app.RunAsync();
