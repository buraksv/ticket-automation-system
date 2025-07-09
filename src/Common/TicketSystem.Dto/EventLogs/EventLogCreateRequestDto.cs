using System.Text.Json.Serialization;
using Gronio.Utility.Common.Models;
using TicketSystem.Enums;

namespace TicketSystem.Dto.EventLogs;

public sealed class EventLogCreateRequestDto : IDto
{
    [JsonIgnore]
    public short? AdminId { get; set; }
    
    [JsonIgnore]
    public string IpAddress { get; set; }
    public EventLogTypeEnum Type { get; set; }
    public string Message { get; set; }
}