using System.Text.Json.Serialization;
using Gronio.Utility.Common.Models;

namespace TicketSystem.Dto.Admin;

public sealed class AdminLoginRequestDto : IDto
{
    public string Username { get; set; }
    public string Password { get; set; }

    [JsonIgnore] 
    public string IpAddress { get; set; } = null;
}