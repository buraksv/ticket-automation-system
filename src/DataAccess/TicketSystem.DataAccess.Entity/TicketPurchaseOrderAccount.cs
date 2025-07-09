using Gronio.Database.Abstraction;

namespace TicketSystem.DataAccess.Entity;

public sealed class TicketPurchaseOrderAccount : Entity<int>, IHasCreatedTimeEntity, IHasUpdatedTimeEntity, IHasDeletedTimeEntity, ITrashableEntity
{
    public short AdminId { get; set; }
    public int TicketPurchaseOrderId { get; set; }
    public int TicketAccountDefinitionId { get; set; }
    public Dictionary<string, string> TicketEventOrderSelections { get; set; }
    public short Count { get; set; }
    public short OrderedCount { get; set; } 
    public DateTime CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
    public DateTime? DeletedTime { get; set; }
    public bool IsDeleted { get; set; }

    public TicketPurchaseOrder TicketPurchaseOrder { get; set; }
    public TicketAccountDefinition TicketAccountDefinition { get; set; }
    public Admin Admin { get; set; }
}