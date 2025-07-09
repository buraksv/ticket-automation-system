using Gronio.Database.Abstraction;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.Business.WebHelpers;
using TicketSystem.Common.Constants;
using TicketSystem.Dto.TicketPurchaseOrderSystemLogs;

namespace TicketSystem.WebApi.Controllers;

[ApiController]
[Route(ApplicationConstants.TicketPurchaseOrderSystemLogControllerBaseRoute)]
public sealed class TicketPurchaseOrderSystemLogController : BaseController
{
    private readonly ITicketPurchaseOrderSystemLogManager _ticketPurchaseOrderSystemLogManager;

    public TicketPurchaseOrderSystemLogController(ITicketPurchaseOrderSystemLogManager ticketPurchaseOrderSystemLogManager)
    {
        _ticketPurchaseOrderSystemLogManager = ticketPurchaseOrderSystemLogManager;
    }

    [HttpPost]
    public async ValueTask<TicketPurchaseOrderSystemLogListItemDto> CreateAsync(TicketPurchaseOrderSystemLogCreateRequestDto request,
        CancellationToken cancellationToken = new())
    {
        return await _ticketPurchaseOrderSystemLogManager.CreateAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpPost(ApplicationConstants.SearchEndpoint)]
    public async ValueTask<PagedResult<TicketPurchaseOrderSystemLogListItemDto>> SearchAsync(TicketPurchaseOrderSystemLogSearchRequestDto request, CancellationToken cancellationToken = new())
    {
        return await _ticketPurchaseOrderSystemLogManager.PagedListAsync(request, cancellationToken).ConfigureAwait(false);
    }
}