using Gronio.Database.Abstraction;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.Business.WebHelpers;
using TicketSystem.Common.Constants;
using TicketSystem.Dto.TicketPurchaseOrders;

namespace TicketSystem.WebApi.Controllers;

[ApiController]
[Route(ApplicationConstants.TicketPurchaseOrderControllerBaseRoute)]
public sealed class TicketPurchaseOrderController : BaseController
{
    private readonly ITicketPurchaseOrderManager _ticketPurchaseOrderManager;

    public TicketPurchaseOrderController(ITicketPurchaseOrderManager ticketPurchaseOrderManager)
    {
        _ticketPurchaseOrderManager = ticketPurchaseOrderManager;
    }

    [HttpPost]
    public async ValueTask<TicketPurchaseOrderDetailDto> CreateAsync(TicketPurchaseOrderCreateRequestDto request, CancellationToken cancellationToken = new())
    {
        request.AdminId = AdminId;
        request.IpAddress = IpAddress;

        return await _ticketPurchaseOrderManager.CreateAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpPut]
    public async ValueTask<TicketPurchaseOrderDetailDto> UpdateAsync(TicketPurchaseOrderUpdateRequestDto request, CancellationToken cancellationToken = new())
    {
        request.AdminId = AdminId;
        request.IpAddress = IpAddress;

        return await _ticketPurchaseOrderManager.UpdateAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpPost(ApplicationConstants.SearchEndpoint)]
    public async ValueTask<PagedResult<TicketPurchaseOrderListItemDto>> SearchAsync(TicketPurchaseOrderSearchRequestDto request, CancellationToken cancellationToken = new())
    {
        return await _ticketPurchaseOrderManager.PagedListAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpGet("{id:int}")]
    public async ValueTask<TicketPurchaseOrderDetailDto> GetByIdAsync([FromRoute] TicketPurchaseOrderGetByIdRequestDto request, CancellationToken cancellationToken = new())
    {
        return await _ticketPurchaseOrderManager.GetByIdAsync(request, cancellationToken).ConfigureAwait(false);
    }
}