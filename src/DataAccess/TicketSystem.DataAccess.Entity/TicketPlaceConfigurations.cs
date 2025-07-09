using Gronio.Database.Abstraction;
using TicketSystem.Enums;

namespace TicketSystem.DataAccess.Entity;

public sealed class TicketPlaceConfigurations : Entity<short>, IHasCreatedTimeEntity
{
    public short TicketPlaceId { get; set; }
    public TicketSystemTypeEnum TicketSystem { get; set; }
    public string TicketSystemId { get; set; }
    public Dictionary<string, string> Definitions { get; set; }
    public DateTime CreatedTime { get; set; }
}