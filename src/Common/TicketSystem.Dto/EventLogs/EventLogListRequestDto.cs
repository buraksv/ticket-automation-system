using Gronio.Utility.Common.Models;
using TicketSystem.Enums;

namespace TicketSystem.Dto.EventLogs;

public sealed class EventLogListRequestDto : IDto
{
    public long OffsetId { get; set; } = 0;
    public EventLogTypeEnum LogType { get; set; } = EventLogTypeEnum.None;
    public int Limit { get; set; }
}