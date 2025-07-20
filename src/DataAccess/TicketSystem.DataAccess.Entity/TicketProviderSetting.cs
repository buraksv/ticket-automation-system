using Gronio.Database.Abstraction;
using TicketSystem.Enums;

namespace TicketSystem.DataAccess.Entity;

public sealed class TicketProviderSetting : Entity<int>, IHasCreatedTimeEntity, IHasUpdatedTimeEntity
{
    public TicketSystemTypeEnum Provider { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
}