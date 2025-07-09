using Gronio.Database.Abstraction;
using Gronio.Utility.Helper.Security.Cryptography;
using Mapster;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.Common.Constants;
using TicketSystem.Common.Models.Configurations;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.Admin;

namespace TicketSystem.Business.Managers.Main;

internal class AdminManager : IAdminManager
{
    protected readonly IAdminRepository AdminRepository;
    private readonly IOptionsMonitor<AppSettingConfiguration> _appSettings;

    public AdminManager(IAdminRepository adminRepository, IOptionsMonitor<AppSettingConfiguration> appSettings)
    {
        AdminRepository = adminRepository;
        _appSettings = appSettings;
    }

    public virtual async ValueTask<AdminDetailDto> CreateAsync(AdminCreateRequestDto request, CancellationToken cancellationToken = new())
    {
        var entity = request.Adapt<Admin>();

        var cryptoHelper = new CryptoHelper();

        var hashedPassword = cryptoHelper.GetSha512Hash(request.Password, ApplicationConstants.PasswordHashSalt);
        entity.PasswordHash = hashedPassword;

        await AdminRepository.AddAsync(entity, cancellationToken);

        return entity.Adapt<AdminDetailDto>();
    }

    public virtual async ValueTask<AdminDetailDto> UpdateAsync(AdminUpdateRequestDto request, CancellationToken cancellationToken = new())
    {
        var entity = request.Adapt<Admin>();

        var cryptoHelper = new CryptoHelper();

        var hashedPassword = cryptoHelper.GetSha512Hash(request.Password, ApplicationConstants.PasswordHashSalt);
        entity.PasswordHash = hashedPassword;

        await AdminRepository.UpdateAsync(entity, cancellationToken);

        return entity.Adapt<AdminDetailDto>();
    }

    public virtual ValueTask<AdminDetailDto> GetByIdAsync(AdminGetByIdRequestDto request, CancellationToken cancellationToken = new())
    {
        return AdminRepository.GetByIdAsync(request, cancellationToken);
    }

    public virtual ValueTask<PagedResult<AdminListItemDto>> PagedListAsync(AdminSearchRequestDto request, CancellationToken cancellationToken = new())
    {
        return AdminRepository.PagedListAsync(request, cancellationToken);
    }

    public virtual ValueTask<bool> ToggleStatusAsync(AdminGetByIdRequestDto request, short adminId, string ipAddress, CancellationToken cancellationToken = new())
    {
        return AdminRepository.ToggleStatusAsync(request, cancellationToken);
    }

    public virtual ValueTask<bool> ChangePasswordAsync(AdminChangePasswordRequestDto request, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }

    public virtual async ValueTask<AdminLoginResponseDto> LoginAsync(AdminLoginRequestDto request, CancellationToken cancellationToken = new())
    {
        var response = new AdminLoginResponseDto
        {
            Success = false,
        };

        var cryptoHelper = new CryptoHelper();
        var hashedPassword = cryptoHelper.GetSha512Hash(request.Password, ApplicationConstants.PasswordHashSalt);

        var detail = await AdminRepository.LoginAsync(request.Username, hashedPassword, cancellationToken);

        if (detail != null)
        {
            response.AdminId = detail.Id;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_appSettings.CurrentValue.JwtSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, detail.Id.ToString()),
                    new Claim(ClaimTypes.Name, detail.Username),
                    new Claim(ClaimTypes.Email, detail.MailAddress),
                    new Claim(ClaimTypes.Role, "Admin"),
                }),
                Expires = DateTime.UtcNow.AddMinutes(_appSettings.CurrentValue.JwtSettings.ExpiresInMinutes),
                Issuer = _appSettings.CurrentValue.JwtSettings.Issuer,
                Audience = _appSettings.CurrentValue.JwtSettings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            response.Success = true;
            response.Token = tokenHandler.WriteToken(token);
        }

        return response;
    }

    public ValueTask<bool> LogoutAsync(short adminId, CancellationToken cancellationToken = new())
    {
        return ValueTask.FromResult(true);
    }
}