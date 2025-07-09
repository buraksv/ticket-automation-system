using System.ComponentModel;

namespace TicketSystem.Enums;

public enum TicketPurchaseOrderSystemLogOrderEnum : byte
{
    None = 0,
    [Description("CreatedTime Ascending")]
    CreatedTimeAscending = 1,
    [Description("CreatedTime Descending")]
    CreatedTimeDescending = 2,
}