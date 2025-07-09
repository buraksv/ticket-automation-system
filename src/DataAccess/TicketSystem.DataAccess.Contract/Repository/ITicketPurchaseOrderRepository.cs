using Gronio.Database.Abstraction;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.TicketPurchaseOrders;

namespace TicketSystem.DataAccess.Contract.Repository;

public interface ITicketPurchaseOrderRepository : IRepository
{
    ValueTask<bool> CreateAsync(TicketPurchaseOrder entity, CancellationToken cancellationToken = new());
    ValueTask<bool> UpdateAsync(TicketPurchaseOrder entity, CancellationToken cancellationToken = new());
    ValueTask<TicketPurchaseOrderDetailDto> GetByIdAsync(TicketPurchaseOrderGetByIdRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<PagedResult<TicketPurchaseOrderListItemDto>> PagedListAsync(TicketPurchaseOrderSearchRequestDto request, CancellationToken cancellationToken = new());
}