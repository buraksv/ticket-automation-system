using Gronio.Database.Abstraction;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.TicketPurchaseCompletedOrders;

namespace TicketSystem.DataAccess.Contract.Repository;

public interface ITicketPurchaseCompletedOrderRepository : IRepository
{
    ValueTask<bool> CreateAsync(TicketPurchaseCompletedOrder entity, CancellationToken cancellationToken = new());
    ValueTask<bool> UpdateAsync(TicketPurchaseCompletedOrder entity, CancellationToken cancellationToken = new());
    ValueTask<TicketPurchaseCompletedOrderDetailDto> GetByIdAsync(TicketPurchaseCompletedOrderGetByIdRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<PagedResult<TicketPurchaseCompletedOrderListItemDto>> PagedListAsync(TicketPurchaseCompletedOrderSearchRequestDto request, CancellationToken cancellationToken = new());
}