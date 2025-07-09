using Gronio.Utility.Common.Models;
using TicketSystem.Enums;

namespace TicketSystem.Dto.TicketPurchaseCompletedOrders;

public sealed class TicketPurchaseCompletedOrderSearchRequestDto : PagingSearchBaseDtoBase
{
    public TicketPurchaseOrderSystemLogOrderEnum? Order { get; set; } = TicketPurchaseOrderSystemLogOrderEnum.CreatedTimeDescending;
}