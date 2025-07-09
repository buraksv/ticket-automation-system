using Gronio.Utility.Common.Models;

namespace TicketSystem.Dto.TicketPurchaseOrders;

public sealed class TicketPurchaseOrderGetByIdRequestDto : IDto
{
    public int Id { get; set; }
}