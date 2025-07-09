using Gronio.Database.Abstraction;
using Mapster;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.Teams;

namespace TicketSystem.Business.Managers.Main;

internal class TeamManager : ITeamManager
{
    protected readonly ITeamRepository TeamRepository;

    public TeamManager(ITeamRepository teamRepository)
    {
        TeamRepository = teamRepository;
    }

    public virtual async ValueTask<TeamDetailDto> CreateAsync(TeamCreateRequestDto request, CancellationToken cancellationToken = new())
    {
        var entity = request.Adapt<Team>();

        var result = await TeamRepository.CreateAsync(entity, cancellationToken);

        return entity.Adapt<TeamDetailDto>();
    }

    public virtual async ValueTask<TeamDetailDto> UpdateAsync(TeamUpdateRequestDto request, CancellationToken cancellationToken = new())
    {
        var entity = request.Adapt<Team>();

        var result = await TeamRepository.CreateAsync(entity, cancellationToken);

        return entity.Adapt<TeamDetailDto>();
    }

    public virtual async ValueTask<TeamDetailDto> GetByIdAsync(TeamGetByIdRequestDto request, CancellationToken cancellationToken = new())
    {
        return await TeamRepository.GetByIdAsync(request, cancellationToken);
    }

    public virtual ValueTask<PagedResult<TeamListItemDto>> PagedListAsync(TeamSearchRequestDto request, CancellationToken cancellationToken = new())
    {
        return TeamRepository.PagedListAsync(request, cancellationToken);
    }

    public virtual async ValueTask<bool> ToggleStatusAsync(TeamGetByIdRequestDto request, short adminId, string ipAddress, CancellationToken cancellationToken = new())
    {
        return await TeamRepository.ToggleStatusAsync(request, cancellationToken);
    }
}