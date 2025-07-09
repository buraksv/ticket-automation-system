using Gronio.Utility.Common.Models;

namespace TicketSystem.Dto.TicketPurchaseCompletedOrders;

public sealed class TicketPurchaseCompletedOrderCreateRequestDto : IDto
{
    public int TicketPurchaseOrderId { get; set; }
    public int TicketPurchaseOrderAccountId { get; set; }
    public decimal TicketPrice { get; set; }
    public Dictionary<string, string> TicketOrderedInformations { get; set; }
}