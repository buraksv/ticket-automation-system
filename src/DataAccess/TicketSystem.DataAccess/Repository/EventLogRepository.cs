using Gronio.Database.Abstraction;
using TicketSystem.DataAccess.Context;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.EventLogs;
using TicketSystem.Enums;

namespace TicketSystem.DataAccess.Repository;

internal sealed class EventLogRepository : RepositoryFactory<EventLog, long>, IEventLogRepository
{
    public EventLogRepository(TicketAutomationSystemDbContext context, IServiceProvider serviceProvider)
        : base(context, serviceProvider)
    {
    }

    public async ValueTask<bool> AddAsync(EventLog entity, CancellationToken cancellationToken = new())
    {
        InsertRepository.AddAsync(entity, cancellationToken);
        var result = await InsertRepository.SaveAsync(cancellationToken);
        return result > 0;
    }

    public ValueTask<List<EventLogListItemDto>> GetEventLogsAsync(EventLogListRequestDto request, CancellationToken cancellationToken = new())
    {
        return QueryRepository.GetListAsync<EventLogListItemDto>(x => x.Id < request.OffsetId && ((request.LogType != null && request.LogType != EventLogTypeEnum.None && x.Type == request.LogType) || 1 == 1), orderBy: x => x.OrderByDescending(y => y.Id), topRecords: request.Limit, cancellationToken: cancellationToken);
    }
}