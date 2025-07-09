using Gronio.Utility.Common.Models;
using TicketSystem.Enums;

namespace TicketSystem.Dto.TicketPlaces;

public sealed class TicketPlaceSearchRequestDto : PagingSearchBaseDtoBase
{
    public TicketPlacePagedListOrderEnum? Order { get; set; } = TicketPlacePagedListOrderEnum.CreatedTimeDescending;
}