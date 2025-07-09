using Gronio.Database.Abstraction;
using Mapster;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.TicketPlaces;

namespace TicketSystem.Business.Managers.Main;

internal class TicketPlaceManager : ITicketPlaceManager
{
    protected readonly ITicketPlaceRepository TicketPlaceRepository;

    public TicketPlaceManager(ITicketPlaceRepository ticketPlaceRepository)
    {
        TicketPlaceRepository = ticketPlaceRepository;
    }

    public virtual async ValueTask<TicketPlaceDetailDto> CreateAsync(TicketPlaceCreateRequestDto request, CancellationToken cancellationToken = new())
    {
        var entity = request.Adapt<TicketPlace>();
        var result = await TicketPlaceRepository.CreateAsync(entity, cancellationToken);
        return entity.Adapt<TicketPlaceDetailDto>();
    }

    public virtual async ValueTask<TicketPlaceDetailDto> UpdateAsync(TicketPlaceUpdateRequestDto request, CancellationToken cancellationToken = new())
    {
        var entity = request.Adapt<TicketPlace>();
        var result = await TicketPlaceRepository.CreateAsync(entity, cancellationToken);
        return entity.Adapt<TicketPlaceDetailDto>();
    }

    public virtual async ValueTask<TicketPlaceDetailDto> GetByIdAsync(TicketPlaceGetByIdRequestDto request, CancellationToken cancellationToken = new())
    {
        return await TicketPlaceRepository.GetByIdAsync(request, cancellationToken);
    }

    public virtual ValueTask<PagedResult<TicketPlaceListItemDto>> PagedListAsync(TicketPlaceSearchRequestDto request, CancellationToken cancellationToken = new())
    {
        return TicketPlaceRepository.PagedListAsync(request, cancellationToken);
    }

    public virtual async ValueTask<bool> ToggleStatusAsync(TicketPlaceGetByIdRequestDto request, short adminId, string ipAddress, CancellationToken cancellationToken = new())
    {
        return await TicketPlaceRepository.ToggleStatusAsync(request, cancellationToken);
    }
}