using Gronio.Utility.Common.Models;
using TicketSystem.Enums;

namespace TicketSystem.Dto.TicketPurchaseOrderSystemLogs;

public sealed class TicketPurchaseOrderSystemLogCreateRequestDto : IDto
{
    public SystemLogTypeEnum LogType { get; set; }

    public string LogMessage { get; set; }
}