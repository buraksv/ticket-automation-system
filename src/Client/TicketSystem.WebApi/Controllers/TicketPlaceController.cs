using Gronio.Database.Abstraction;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.Business.WebHelpers;
using TicketSystem.Common.Constants;
using TicketSystem.Dto.TicketPlaces;

namespace TicketSystem.WebApi.Controllers;

[ApiController]
[Route(ApplicationConstants.TicketPlaceDefinitionControllerBaseRoute)]
public sealed class TicketPlaceController : BaseController
{
    private readonly ITicketPlaceManager _ticketPlaceManager;

    public TicketPlaceController(ITicketPlaceManager ticketPlaceManager)
    {
        _ticketPlaceManager = ticketPlaceManager;
    }

    [HttpPost]
    public async ValueTask<TicketPlaceDetailDto> CreateAsync(TicketPlaceCreateRequestDto request, CancellationToken cancellationToken = new())
    {
        request.AdminId = AdminId;
        request.IpAddress = IpAddress;

        return await _ticketPlaceManager.CreateAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpPut]
    public async ValueTask<TicketPlaceDetailDto> UpdateAsync(TicketPlaceUpdateRequestDto request, CancellationToken cancellationToken = new())
    {
        request.AdminId = AdminId;
        request.IpAddress = IpAddress;

        return await _ticketPlaceManager.UpdateAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpGet("{id:int}")]
    public async ValueTask<TicketPlaceDetailDto> GetByIdAsync([FromRoute] TicketPlaceGetByIdRequestDto request, CancellationToken cancellationToken = new())
    {
        return await _ticketPlaceManager.GetByIdAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpPost(ApplicationConstants.SearchEndpoint)]
    public async ValueTask<PagedResult<TicketPlaceListItemDto>> PagedListAsync(TicketPlaceSearchRequestDto request, CancellationToken cancellationToken = new())
    {
        return await _ticketPlaceManager.PagedListAsync(request, cancellationToken).ConfigureAwait(false);

    }

    [HttpPatch("{id:int}/toggle-status")]
    public async ValueTask<bool> ToggleStatusAsync([FromRoute] TicketPlaceGetByIdRequestDto request, CancellationToken cancellationToken = new())
    {
        return await _ticketPlaceManager.ToggleStatusAsync(request, AdminId, IpAddress, cancellationToken).ConfigureAwait(false);
    }
}