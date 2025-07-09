using Gronio.Utility.Common.Models;

namespace TicketSystem.Dto.TicketPurchaseCompletedOrders;

public sealed class TicketPurchaseCompletedOrderUpdateRequestDto : IDto
{
    public int Id { get; set; }
    public decimal TicketPrice { get; set; }
}