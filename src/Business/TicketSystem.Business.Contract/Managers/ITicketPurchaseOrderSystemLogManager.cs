using Gronio.Database.Abstraction;
using Gronio.Utility.Helper.Core.BusinessEngine;
using TicketSystem.Dto.TicketPurchaseOrderSystemLogs;

namespace TicketSystem.Business.Contract.Managers;

public interface ITicketPurchaseOrderSystemLogManager : IBusinessEngine
{
    ValueTask<TicketPurchaseOrderSystemLogListItemDto> CreateAsync(TicketPurchaseOrderSystemLogCreateRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<PagedResult<TicketPurchaseOrderSystemLogListItemDto>> PagedListAsync(TicketPurchaseOrderSystemLogSearchRequestDto request, CancellationToken cancellationToken = new());
}