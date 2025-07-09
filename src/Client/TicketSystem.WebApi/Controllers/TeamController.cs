using Gronio.Database.Abstraction;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.Business.WebHelpers;
using TicketSystem.Common.Constants;
using TicketSystem.Dto.Teams;

namespace TicketSystem.WebApi.Controllers;

[ApiController]
[Route(ApplicationConstants.TeamControllerBaseRoute)]
public sealed class TeamController : BaseController
{
    private readonly ITeamManager _teamManager;

    public TeamController(ITeamManager teamManager)
    {
        _teamManager = teamManager;
    }

    [HttpPost]
    public async ValueTask<TeamDetailDto> CreateAsync(TeamCreateRequestDto request, CancellationToken cancellationToken = new())
    {
        request.AdminId = AdminId;
        request.IpAddress = IpAddress;

        return await _teamManager.CreateAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpPut]
    public async ValueTask<TeamDetailDto> UpdateAsync(TeamUpdateRequestDto request, CancellationToken cancellationToken = new())
    {
        request.AdminId = AdminId;
        request.IpAddress = IpAddress;

        return await _teamManager.UpdateAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpGet("{id:int}")]
    public async ValueTask<TeamDetailDto> GetByIdAsync([FromRoute] TeamGetByIdRequestDto request,
        CancellationToken cancellationToken = new())
    {
        return await _teamManager.GetByIdAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpPost(ApplicationConstants.SearchEndpoint)]
    public async ValueTask<PagedResult<TeamListItemDto>> PagedListAsync(TeamSearchRequestDto request,
        CancellationToken cancellationToken = new())
    {
        return await _teamManager.PagedListAsync(request, cancellationToken).ConfigureAwait(false);

    }

    [HttpPatch("{id:int}/toggle-status")]
    public async ValueTask<bool> ToggleStatusAsync([FromRoute] TeamGetByIdRequestDto request,
        CancellationToken cancellationToken = new())
    {
        return await _teamManager.ToggleStatusAsync(request, AdminId, IpAddress, cancellationToken).ConfigureAwait(false);
    }
}