using Gronio.Database.Abstraction;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.Teams;

namespace TicketSystem.DataAccess.Contract.Repository;

public interface ITeamRepository : IRepository
{
    ValueTask<bool> CreateAsync(Team entity, CancellationToken cancellationToken = new());
    ValueTask<bool> UpdateAsync(Team entity, CancellationToken cancellationToken = new());
    ValueTask<TeamDetailDto> GetByIdAsync(TeamGetByIdRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<PagedResult<TeamListItemDto>> PagedListAsync(TeamSearchRequestDto request, CancellationToken token = new());
    ValueTask<bool> ToggleStatusAsync(TeamGetByIdRequestDto request, CancellationToken cancellationToken = new());
}