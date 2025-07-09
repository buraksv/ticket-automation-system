using Gronio.Utility.Common.Models;
using TicketSystem.Enums;

namespace TicketSystem.Dto.TicketPurchaseOrderSystemLogs;

public sealed class TicketPurchaseOrderSystemLogListItemDto : IDto
{
    public long Id { get; set; }
    
    public SystemLogTypeEnum LogType { get; set; }
    
    public string LogMessage { get; set; }
    
    public DateTime CreatedTime { get; set; }
}
