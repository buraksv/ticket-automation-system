namespace TicketSystem.Common.Models.Configurations;

public sealed class AppSettingConfiguration
{
    public JwtSettings JwtSettings { get; set; }
}

public class JwtSettings
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SecretKey { get; set; }
    public int ExpiresInMinutes { get; set; }
}