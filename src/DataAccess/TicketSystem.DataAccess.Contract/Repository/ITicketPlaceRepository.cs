using Gronio.Database.Abstraction;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.TicketPlaces;

namespace TicketSystem.DataAccess.Contract.Repository;

public interface ITicketPlaceRepository : IRepository
{
    ValueTask<bool> CreateAsync(TicketPlace entity, CancellationToken cancellationToken = new());
    ValueTask<bool> UpdateAsync(TicketPlace entity, CancellationToken cancellationToken = new());
    ValueTask<TicketPlaceDetailDto> GetByIdAsync(TicketPlaceGetByIdRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<PagedResult<TicketPlaceListItemDto>> PagedListAsync(TicketPlaceSearchRequestDto request, CancellationToken token = new());
    ValueTask<bool> ToggleStatusAsync(TicketPlaceGetByIdRequestDto request, CancellationToken cancellationToken = new());
}