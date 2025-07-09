using Gronio.Database.Abstraction;
using TicketSystem.Enums;

namespace TicketSystem.DataAccess.Entity;

public sealed class TicketPurchaseOrder : Entity<int>, IHasCreatedTimeEntity,IHasUpdatedTimeEntity,IStatusEntity
{
    public short AdminId { get; set; }
    public string Name { get; set; }
    public short TeamId { get; set; }
    public TicketSystemTypeEnum TicketSystem { get; set; }
    public short TicketPlaceId { get; set; }
    public string TicketEventId { get; set; }
    public DateTime EventTime { get; set; }
    public DateTime AutomationRunTime { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
    public bool IsActive { get; set; }

    public TicketPlace TicketPlace { get; set; }
    public Team Team { get; set; }
    public Admin Admin { get; set; }
}