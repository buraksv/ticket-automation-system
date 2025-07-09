using Microsoft.AspNetCore.Mvc;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.Business.WebHelpers;
using TicketSystem.Common.Constants;
using TicketSystem.Dto.EventLogs;
using TicketSystem.Enums;

namespace TicketSystem.WebApi.Controllers;

[ApiController]
[Route(ApplicationConstants.EventLogsControllerBaseRoute)]
public sealed class EventLogController : BaseController
{
    private readonly IEventLogManager _eventLogManager;

    public EventLogController(IEventLogManager eventLogManager)
    {
        _eventLogManager = eventLogManager;
    }

    [HttpGet]
    public async ValueTask<List<EventLogListItemDto>> GetEventLogs(long offsetId = 0, int limit = 50, EventLogTypeEnum type = EventLogTypeEnum.None, CancellationToken cancellationToken = new())
    {
        var request = new EventLogListRequestDto
        {
            Limit = limit,
            OffsetId = offsetId,
            LogType = type,
        };

        return await _eventLogManager.GetEventLogAsync(request, cancellationToken);
    }
}