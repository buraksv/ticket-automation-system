using Microsoft.AspNetCore.Mvc;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.Business.WebHelpers;
using TicketSystem.Common.Constants;
using TicketSystem.Dto.TicketPurchaseOrderAccounts;

namespace TicketSystem.WebApi.Controllers;

[ApiController]
[Route(ApplicationConstants.TicketPurchaseOrderAccountControllerBaseRoute)]
public sealed class TicketPurchaseOrderAccountController : BaseController
{
    private readonly ITicketPurchaseOrderAccountManager _ticketPurchaseOrderAccountManager;

    public TicketPurchaseOrderAccountController(ITicketPurchaseOrderAccountManager ticketPurchaseOrderAccountManager)
    {
        _ticketPurchaseOrderAccountManager = ticketPurchaseOrderAccountManager;
    }

    [HttpPost]
    public async ValueTask<TicketPurchaseOrderAccountDetailDto> CreateAsync(TicketPurchaseOrderAccountCreateRequestDto request,
        CancellationToken cancellationToken = new())
    {
        request.AdminId = AdminId;
        request.IpAddress = IpAddress;

        return await _ticketPurchaseOrderAccountManager.CreateAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpPut]
    public async ValueTask<TicketPurchaseOrderAccountDetailDto> UpdateAsync(TicketPurchaseOrderAccountUpdateRequestDto request,
        CancellationToken cancellationToken = new())
    {
        request.AdminId = AdminId;
        request.IpAddress = IpAddress;

        return await _ticketPurchaseOrderAccountManager.UpdateAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpGet("{orderId:int}")]
    public async ValueTask<List<TicketPurchaseOrderAccountListItemDto>> GetAccountsByOrderIdAsync([FromRoute] TicketPurchaseOrderAccountGetByOrderIdRequestDto request, CancellationToken cancellationToken = new())
    {
        return await _ticketPurchaseOrderAccountManager.GetAccountsByOrderIdAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpDelete("{id:int}")]
    public async ValueTask<bool> DeleteAsync([FromRoute] TicketPurchaseOrderAccountGetByIdRequestDto request, CancellationToken cancellationToken = new())
    {
        return await _ticketPurchaseOrderAccountManager.DeleteAsync(request, AdminId, IpAddress, cancellationToken).ConfigureAwait(false);
    }
}