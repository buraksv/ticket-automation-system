using Gronio.Database.Abstraction;
using Gronio.Utility.Helper.Core.BusinessEngine;
using TicketSystem.Dto.Teams;

namespace TicketSystem.Business.Contract.Managers;

public interface ITeamManager : IBusinessEngine
{
    ValueTask<TeamDetailDto> CreateAsync(TeamCreateRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<TeamDetailDto> UpdateAsync(TeamUpdateRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<TeamDetailDto> GetByIdAsync(TeamGetByIdRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<PagedResult<TeamListItemDto>> PagedListAsync(TeamSearchRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<bool> ToggleStatusAsync(TeamGetByIdRequestDto request, short adminId, string ipAddress, CancellationToken cancellationToken = new());
}