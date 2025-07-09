using Gronio.Database.Abstraction;
using TicketSystem.Enums;

namespace TicketSystem.DataAccess.Entity;

public sealed class Team : Entity<short>, IHasCreatedTimeEntity, IStatusEntity, IUndeletableEntity
{
    public short AdminId { get; set; }
    public string TeamName { get; set; }
    public TicketSystemTypeEnum TicketSystem { get; set; }
    public string TicketSystemId { get; set; } 
    public DateTime CreatedTime { get; set; }
    public bool IsActive { get; set; }
}