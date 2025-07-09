using System.Text.Json.Serialization;
using Gronio.Utility.Common.Models;

namespace TicketSystem.Dto.Admin;

public sealed class AdminUpdateRequestDto : IDto
{
    [JsonIgnore]
    public short AdminId { get; set; }
    [JsonIgnore]
    public string IpAddress { get; set; }
    
    public short Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string MailAddress { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; }
}