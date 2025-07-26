using Gronio.Database.Abstraction;

namespace TicketSystem.DataAccess.Entity;

public sealed class TicketAccountDefinitionSetting : Entity<int>, IHasCreatedTimeEntity, IHasUpdatedTimeEntity
{
    public int TicketAccountDefinitionId { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }

    public TicketAccountDefinition TicketAccountDefinition { get; set; }
}
