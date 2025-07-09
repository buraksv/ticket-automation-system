using Gronio.Utility.Common.Models;

namespace TicketSystem.Dto.TicketPurchaseOrderAccounts;

public sealed class TicketPurchaseOrderAccountGetByIdRequestDto : IDto
{
    public int Id { get; set; }
}