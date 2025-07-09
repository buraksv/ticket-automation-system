using System.ComponentModel;

namespace TicketSystem.Enums;

public enum TicketPurchaseOrderOrderEnum
{
    None = 0,
    [Description("Name Ascending")]
    NameAscending = 1,
    [Description("Name Descending")]
    NameDescending = 2,
    [Description("CreatedTime Ascending")]
    CreatedTimeAscending = 3,
    [Description("CreatedTime Descending")]
    CreatedTimeDescending = 4,
}