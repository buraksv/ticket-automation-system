using Gronio.Database.Abstraction;
using Gronio.Utility.Helper.Core.BusinessEngine;
using TicketSystem.Dto.TicketAccountDefinitions;

namespace TicketSystem.Business.Contract.Managers;

public interface ITicketAccountDefinitionManager : IBusinessEngine
{
    ValueTask<TicketAccountDefinitionDetailDto> CreateAsync(TicketAccountDefinitionCreateRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<TicketAccountDefinitionDetailDto> UpdateAsync(TicketAccountDefinitionUpdateRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<TicketAccountDefinitionDetailDto> GetByIdAsync(TicketAccountDefinitionGetByIdRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<PagedResult<TicketAccountDefinitionListItemDto>> PagedListAsync(TicketAccountDefinitionSearchRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<bool> ToggleStatusAsync(TicketAccountDefinitionGetByIdRequestDto request, short adminId, string ipAddress, CancellationToken cancellationToken = new());
}