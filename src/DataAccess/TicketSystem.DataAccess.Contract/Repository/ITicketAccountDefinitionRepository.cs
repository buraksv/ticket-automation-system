using Gronio.Database.Abstraction;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.TicketAccountDefinitions;

namespace TicketSystem.DataAccess.Contract.Repository;

public interface ITicketAccountDefinitionRepository : IRepository
{
    ValueTask<bool> CreateAsync(TicketAccountDefinition entity, CancellationToken cancellationToken = new());
    ValueTask<bool> UpdateAsync(TicketAccountDefinition entity, CancellationToken cancellationToken = new());
    ValueTask<TicketAccountDefinitionDetailDto> GetByIdAsync(TicketAccountDefinitionGetByIdRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<PagedResult<TicketAccountDefinitionListItemDto>> PagedListAsync(TicketAccountDefinitionSearchRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<bool> ToggleStatusAsync(TicketAccountDefinitionGetByIdRequestDto request, CancellationToken cancellationToken = new());
}