using Gronio.Database.Abstraction;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.EventLogs;

namespace TicketSystem.DataAccess.Contract.Repository;

public interface IEventLogRepository : IRepository
{
    ValueTask<bool> AddAsync(EventLog entity, CancellationToken cancellationToken = new());
    ValueTask<List<EventLogListItemDto>> GetEventLogsAsync(EventLogListRequestDto request, CancellationToken cancellationToken = new());
}