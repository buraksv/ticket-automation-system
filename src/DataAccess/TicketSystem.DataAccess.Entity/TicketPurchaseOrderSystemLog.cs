using Gronio.Database.Abstraction;
using TicketSystem.Enums;

namespace TicketSystem.DataAccess.Entity;

public sealed class TicketPurchaseOrderSystemLog : Entity<long>, IHasCreatedTimeEntity
{
    public SystemLogTypeEnum LogType { get; set; }
    public string LogMessage { get; set; }
    public DateTime CreatedTime { get; set; }
}