using Gronio.Utility.Common.Models;
using TicketSystem.Dto.TicketPurchaseOrderAccounts;
using TicketSystem.Dto.TicketPurchaseOrders;

namespace TicketSystem.Dto.TicketPurchaseCompletedOrders;

public sealed class TicketPurchaseCompletedOrderDetailDto : IDto
{
    public int Id { get; set; }
    public int TicketPurchaseOrderId { get; set; }
    public int TicketPurchaseOrderAccountId { get; set; }
    public Dictionary<string, string> TicketOrderedInformations { get; set; }
    public DateTime CreatedTime { get; set; }

    public TicketPurchaseOrderDetailDto TicketPurchaseOrder { get; set; }
    public TicketPurchaseOrderAccountDetailDto TicketPurchaseOrderAccount { get; set; }
}
