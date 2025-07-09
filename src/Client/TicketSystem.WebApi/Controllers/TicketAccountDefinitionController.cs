using Gronio.Database.Abstraction;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.Business.WebHelpers;
using TicketSystem.Common.Constants;
using TicketSystem.Dto.TicketAccountDefinitions;

namespace TicketSystem.WebApi.Controllers;

[ApiController]
[Route(ApplicationConstants.TicketAccountDefinitionControllerBaseRoute)]
public sealed class TicketAccountDefinitionController : BaseController
{
    private readonly ITicketAccountDefinitionManager _ticketAccountDefinitionManager;

    public TicketAccountDefinitionController(ITicketAccountDefinitionManager ticketAccountDefinitionManager)
    {
        _ticketAccountDefinitionManager = ticketAccountDefinitionManager;
    }

    [HttpPost]
    public async ValueTask<TicketAccountDefinitionDetailDto> CreateAsync(TicketAccountDefinitionCreateRequestDto request,
        CancellationToken cancellationToken = new())
    {
        request.AdminId = AdminId;
        request.IpAddress = IpAddress;

        return await _ticketAccountDefinitionManager.CreateAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpPut]
    public async ValueTask<TicketAccountDefinitionDetailDto> UpdateAsync(TicketAccountDefinitionUpdateRequestDto request,
        CancellationToken cancellationToken = new())
    {
        request.AdminId = AdminId;
        request.IpAddress = IpAddress;

        return await _ticketAccountDefinitionManager.UpdateAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpGet("{id:int}")]
    public async ValueTask<TicketAccountDefinitionDetailDto> GetByIdAsync([FromRoute] TicketAccountDefinitionGetByIdRequestDto request,
        CancellationToken cancellationToken = new())
    {
        return await _ticketAccountDefinitionManager.GetByIdAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpPost(ApplicationConstants.SearchEndpoint)]
    public async ValueTask<PagedResult<TicketAccountDefinitionListItemDto>> PagedListAsync(TicketAccountDefinitionSearchRequestDto request, CancellationToken cancellationToken = new())
    {
        return await _ticketAccountDefinitionManager.PagedListAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpPatch("{id:int}/toggle-status")]
    public async ValueTask<bool> ToggleStatusAsync([FromRoute] TicketAccountDefinitionGetByIdRequestDto request,
        CancellationToken cancellationToken = new())
    {
        return await _ticketAccountDefinitionManager.ToggleStatusAsync(request, AdminId, IpAddress, cancellationToken).ConfigureAwait(false);
    }
}