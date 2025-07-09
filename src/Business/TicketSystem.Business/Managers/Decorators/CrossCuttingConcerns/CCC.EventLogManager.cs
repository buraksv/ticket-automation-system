using Gronio.Utility.Helper.Validation;
using TicketSystem.Business.Managers.Main;
using TicketSystem.Business.Validators.EventLogValidators;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.Dto.EventLogs;

namespace TicketSystem.Business.Managers;

internal sealed class CccEventLogManager : EventLogManager
{
    public CccEventLogManager(IEventLogRepository eventLogRepository) 
        : base(eventLogRepository)
    {
    }

    public override ValueTask<bool> AddEventLogAsync(EventLogCreateRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<EventLogAddValidator>(request);

        return base.AddEventLogAsync(request, cancellationToken);
    }

    public override ValueTask<List<EventLogListItemDto>> GetEventLogAsync(EventLogListRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<EventLogGetValidator>(request);

        return base.GetEventLogAsync(request, cancellationToken);
    }
}