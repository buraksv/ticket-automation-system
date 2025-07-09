using Gronio.Utility.Common.Models;
using TicketSystem.Enums;

namespace TicketSystem.Dto.TicketPurchaseOrders;

public sealed class TicketPurchaseOrderSearchRequestDto : PagingSearchBaseDtoBase
{
    public TicketPurchaseOrderOrderEnum? Order { get; set; } = TicketPurchaseOrderOrderEnum.CreatedTimeDescending;
    public short? TeamId { get; set; }
    public TicketSystemTypeEnum TicketSystem { get; set; }
}