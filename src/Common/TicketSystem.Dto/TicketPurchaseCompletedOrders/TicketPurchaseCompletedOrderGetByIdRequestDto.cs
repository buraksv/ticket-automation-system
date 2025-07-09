using Gronio.Utility.Common.Models;

namespace TicketSystem.Dto.TicketPurchaseCompletedOrders;

public sealed class TicketPurchaseCompletedOrderGetByIdRequestDto : IDto
{
    public int Id { get; set; }
}