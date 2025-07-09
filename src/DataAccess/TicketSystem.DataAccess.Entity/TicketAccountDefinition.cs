using Gronio.Database.Abstraction;
using TicketSystem.Enums;

namespace TicketSystem.DataAccess.Entity;

public sealed class TicketAccountDefinition : Entity<int>, IHasCreatedTimeEntity, IHasUpdatedTimeEntity, IStatusEntity, IUndeletableEntity
{
    public short AdminId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public TicketAccountTypeEnum AccountType { get; set; }
    public TicketSystemTypeEnum TicketSystem { get; set; }
    public short TeamId { get; set; }
    public Dictionary<string, string> TicketSystemLoginInformation { get; set; }
    public bool TicketSystemIsValid { get; set; }
    public DateTime? TicketSystemLastValidationControlTime { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
    public bool IsActive { get; set; }

    public Team Team { get; set; }
    public Admin Admin { get; set; }
}