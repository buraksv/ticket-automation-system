using System.ComponentModel;

namespace TicketSystem.Enums;

public enum TeamPagedListOrderEnum : byte
{
    None = 0,
    [Description("Team Name Ascending")]
    TeamNameAscending = 1,
    [Description("Team Name Descending")]
    TeamNameDescending = 2,
    [Description("CreatedTime Ascending")]
    CreatedTimeAscending = 3,
    [Description("CreatedTime Descending")]
    CreatedTimeDescending = 4,
}