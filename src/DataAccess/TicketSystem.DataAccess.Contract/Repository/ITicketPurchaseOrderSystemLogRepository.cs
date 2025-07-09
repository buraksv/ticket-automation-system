using Gronio.Database.Abstraction;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.TicketPurchaseOrderSystemLogs;

namespace TicketSystem.DataAccess.Contract.Repository;

public interface ITicketPurchaseOrderSystemLogRepository : IRepository
{
    ValueTask<bool> CreateAsync(TicketPurchaseOrderSystemLog entity, CancellationToken cancellationToken = new());
    ValueTask<PagedResult<TicketPurchaseOrderSystemLogListItemDto>> PagedListAsync(TicketPurchaseOrderSystemLogSearchRequestDto request, CancellationToken cancellationToken = new());
}