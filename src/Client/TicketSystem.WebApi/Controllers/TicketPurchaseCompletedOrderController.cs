using Gronio.Database.Abstraction;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.Business.WebHelpers;
using TicketSystem.Common.Constants;
using TicketSystem.Dto.TicketPurchaseCompletedOrders;

namespace TicketSystem.WebApi.Controllers;

[ApiController]
[Route(ApplicationConstants.TicketPurchaseCompletedOrderControllerBaseRoute)]
public sealed class TicketPurchaseCompletedOrderController : BaseController
{
    private readonly ITicketPurchaseCompletedOrderManager _ticketPurchaseCompletedOrderManager;

    public TicketPurchaseCompletedOrderController(ITicketPurchaseCompletedOrderManager ticketPurchaseCompletedOrderManager)
    {
        _ticketPurchaseCompletedOrderManager = ticketPurchaseCompletedOrderManager;
    }

    [HttpPost]
    public async ValueTask<TicketPurchaseCompletedOrderDetailDto> CreateAsync(TicketPurchaseCompletedOrderCreateRequestDto request,
        CancellationToken cancellationToken = new())
    {
        return await _ticketPurchaseCompletedOrderManager.CreateAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpPut]
    public async ValueTask<TicketPurchaseCompletedOrderDetailDto> UpdateAsync(TicketPurchaseCompletedOrderUpdateRequestDto request,
        CancellationToken cancellationToken = new())
    {
        return await _ticketPurchaseCompletedOrderManager.UpdateAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpGet("{id:int}")]
    public async ValueTask<TicketPurchaseCompletedOrderDetailDto> GetByIdAsync([FromRoute] TicketPurchaseCompletedOrderGetByIdRequestDto request,
        CancellationToken cancellationToken = new())
    {
        return await _ticketPurchaseCompletedOrderManager.GetByIdAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpPost(ApplicationConstants.SearchEndpoint)]
    public async ValueTask<PagedResult<TicketPurchaseCompletedOrderListItemDto>> PagedListAsync(TicketPurchaseCompletedOrderSearchRequestDto request, CancellationToken cancellationToken = new())
    {
        return await _ticketPurchaseCompletedOrderManager.PagedListAsync(request, cancellationToken).ConfigureAwait(false);
    }
}