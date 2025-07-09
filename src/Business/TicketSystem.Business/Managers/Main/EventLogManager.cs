using Mapster;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.EventLogs;

namespace TicketSystem.Business.Managers.Main;

internal class EventLogManager : IEventLogManager
{
    protected readonly IEventLogRepository EventLogRepository;

    public EventLogManager(IEventLogRepository eventLogRepository)
    {
        EventLogRepository = eventLogRepository;
    }

    public virtual ValueTask<bool> AddEventLogAsync(EventLogCreateRequestDto request, CancellationToken cancellationToken = new())
    {
        var entity = request.Adapt<EventLog>();
        return EventLogRepository.AddAsync(entity, cancellationToken);
    }

    public virtual ValueTask<List<EventLogListItemDto>> GetEventLogAsync(EventLogListRequestDto request, CancellationToken cancellationToken = new())
    {
        return EventLogRepository.GetEventLogsAsync(request, cancellationToken);
    }
}