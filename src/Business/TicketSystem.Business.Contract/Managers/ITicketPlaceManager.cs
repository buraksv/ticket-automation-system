using Gronio.Database.Abstraction;
using TicketSystem.Dto.TicketPlaces;

namespace TicketSystem.Business.Contract.Managers;

public interface ITicketPlaceManager
{
    ValueTask<TicketPlaceDetailDto> CreateAsync(TicketPlaceCreateRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<TicketPlaceDetailDto> UpdateAsync(TicketPlaceUpdateRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<TicketPlaceDetailDto> GetByIdAsync(TicketPlaceGetByIdRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<PagedResult<TicketPlaceListItemDto>> PagedListAsync(TicketPlaceSearchRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<bool> ToggleStatusAsync(TicketPlaceGetByIdRequestDto request, short adminId, string ipAddress, CancellationToken cancellationToken = new());
}