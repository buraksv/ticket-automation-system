using Gronio.Utility.Common.Models;
using TicketSystem.Dto.Admin;
using TicketSystem.Enums;

namespace TicketSystem.Dto.EventLogs;

public sealed class EventLogListItemDto : IDto
{
    public long Id { get; set; }
    public EventLogTypeEnum Type { get; set; }
    public string Message { get; set; }
    public DateTime CreatedTime { get; set; }

    public AdminDetailDto? Admin { get; set; }
}