using Gronio.Database.Abstraction;

namespace TicketSystem.DataAccess.Entity;

public sealed class SystemSettings : Entity<byte>, IHasUpdatedTimeEntity, IUndeletableEntity
{
    public string SystemName { get; set; }
    public DateTime? UpdatedTime { get; set; }
}