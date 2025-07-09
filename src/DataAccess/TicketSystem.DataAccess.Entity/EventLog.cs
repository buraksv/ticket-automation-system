using Gronio.Database.Abstraction;
using TicketSystem.Enums;

namespace TicketSystem.DataAccess.Entity;

public sealed class EventLog : Entity<long>, IHasCreatedTimeEntity
{
    public short? AdminId { get; set; }
    public string IpAddress { get; set; }
    public EventLogTypeEnum Type { get; set; }
    public string Message { get; set; }
    public DateTime CreatedTime { get; set; }

    public Admin? Admin { get; set; }
}