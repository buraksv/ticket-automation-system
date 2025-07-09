using Gronio.Utility.Common.Models;

namespace TicketSystem.Dto.TicketPurchaseOrderAccounts;

public sealed class TicketPurchaseOrderAccountGetByOrderIdRequestDto : IDto
{
    public int OrderId { get; set; }
}