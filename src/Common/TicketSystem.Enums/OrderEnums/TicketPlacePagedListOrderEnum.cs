using System.ComponentModel;

namespace TicketSystem.Enums;

public enum TicketPlacePagedListOrderEnum : byte
{
    None = 0,
    [Description("Place Name Ascending")]
    PlaceNameAscending = 1,
    [Description("Place Name Descending")]
    PlaceNameDescending = 2,
    [Description("CreatedTime Ascending")]
    CreatedTimeAscending = 3,
    [Description("CreatedTime Descending")]
    CreatedTimeDescending = 4,
}