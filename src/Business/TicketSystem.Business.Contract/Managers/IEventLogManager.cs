using Gronio.Utility.Helper.Core.BusinessEngine;
using TicketSystem.Dto.EventLogs;

namespace TicketSystem.Business.Contract.Managers;

public interface IEventLogManager : IBusinessEngine
{
    ValueTask<bool> AddEventLogAsync(EventLogCreateRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<List<EventLogListItemDto>> GetEventLogAsync(EventLogListRequestDto request, CancellationToken cancellationToken = new());
}