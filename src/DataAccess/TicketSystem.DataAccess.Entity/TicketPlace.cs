using Gronio.Database.Abstraction;

namespace TicketSystem.DataAccess.Entity;

public sealed class TicketPlace : Entity<short>, IHasCreatedTimeEntity, IHasUpdatedTimeEntity, IStatusEntity, IUndeletableEntity
{
    public short AdminId { get; set; }
    public string PlaceName { get; set; } 
    public DateTime CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
    public bool IsActive { get; set; }

    public TicketPlaceConfigurations TicketPlaceConfigurations { get; set; }
}