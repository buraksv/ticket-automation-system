using Gronio.Database.Abstraction;

namespace TicketSystem.DataAccess.Entity;

public sealed class TicketPurchaseCompletedOrder : Entity<int>, IHasCreatedTimeEntity, IHasUpdatedTimeEntity, IUndeletableEntity
{
    public int TicketPurchaseOrderId { get; set; }
    public int TicketPurchaseOrderAccountId { get; set; }
    public Dictionary<string, string> TicketOrderedInformations { get; set; }
    public decimal TicketPrice { get; set; }
    public decimal TicketSalePrice { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
    
    public TicketPurchaseOrder TicketPurchaseOrder { get; set; }
    public TicketPurchaseOrderAccount TicketPurchaseOrderAccount { get; set; }
}