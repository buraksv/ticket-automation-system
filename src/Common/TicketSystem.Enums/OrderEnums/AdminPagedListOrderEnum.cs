using System.ComponentModel;

namespace TicketSystem.Enums;

public enum AdminPagedListOrderEnum : byte
{
    None=0,
    [Description("User Name Ascending")]
    UserNameAscending = 1,
    [Description("User Name Descending")]
    UserNameDescending = 2,
    [Description("CreatedTime Ascending")]
    CreatedTimeAscending = 3,
    [Description("CreatedTime Descending")]
    CreatedTimeDescending = 4,
}