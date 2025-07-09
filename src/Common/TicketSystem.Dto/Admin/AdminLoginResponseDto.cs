using System.Text.Json.Serialization;
using Gronio.Utility.Common.Models;

namespace TicketSystem.Dto.Admin;

public sealed class AdminLoginResponseDto : IDto
{
    public bool Success { get; set; }
    public string Token { get; set; }
    
    [JsonIgnore]
    public short? AdminId { get; set; }
}