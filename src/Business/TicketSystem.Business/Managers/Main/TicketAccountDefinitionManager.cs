using Gronio.Database.Abstraction;
using Mapster;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.TicketAccountDefinitions;

namespace TicketSystem.Business.Managers.Main;

internal class TicketAccountDefinitionManager : ITicketAccountDefinitionManager
{
    protected readonly ITicketAccountDefinitionRepository TicketAccountDefinitionRepository;

    public TicketAccountDefinitionManager(ITicketAccountDefinitionRepository ticketAccountDefinitionRepository)
    {
        TicketAccountDefinitionRepository = ticketAccountDefinitionRepository;
    }

    public virtual async ValueTask<TicketAccountDefinitionDetailDto> CreateAsync(TicketAccountDefinitionCreateRequestDto request,
        CancellationToken cancellationToken = new())
    {
        var entity = request.Adapt<TicketAccountDefinition>();

        var result = await TicketAccountDefinitionRepository.CreateAsync(entity, cancellationToken);

        return entity.Adapt<TicketAccountDefinitionDetailDto>();
    }

    public virtual async ValueTask<TicketAccountDefinitionDetailDto> UpdateAsync(TicketAccountDefinitionUpdateRequestDto request,
        CancellationToken cancellationToken = new())
    {
        var entity = request.Adapt<TicketAccountDefinition>();

        var result = await TicketAccountDefinitionRepository.UpdateAsync(entity, cancellationToken);

        return entity.Adapt<TicketAccountDefinitionDetailDto>();
    }

    public virtual async ValueTask<TicketAccountDefinitionDetailDto> GetByIdAsync(TicketAccountDefinitionGetByIdRequestDto request,
        CancellationToken cancellationToken = new())
    {
        return await TicketAccountDefinitionRepository.GetByIdAsync(request, cancellationToken);
    }

    public virtual ValueTask<PagedResult<TicketAccountDefinitionListItemDto>> PagedListAsync(TicketAccountDefinitionSearchRequestDto request,
        CancellationToken cancellationToken = new())
    {
        return TicketAccountDefinitionRepository.PagedListAsync(request, cancellationToken);
    }

    public virtual async ValueTask<bool> ToggleStatusAsync(TicketAccountDefinitionGetByIdRequestDto request, short adminId, string ipAddress,
        CancellationToken cancellationToken = new())
    {
        return await TicketAccountDefinitionRepository.ToggleStatusAsync(request, cancellationToken);
    }
}