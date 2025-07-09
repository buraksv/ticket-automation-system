using Gronio.Database.Abstraction;
using Gronio.Utility.Helper.Core.BusinessEngine;
using TicketSystem.Dto.TicketPurchaseCompletedOrders;

namespace TicketSystem.Business.Contract.Managers;

public interface ITicketPurchaseCompletedOrderManager : IBusinessEngine
{
    ValueTask<TicketPurchaseCompletedOrderDetailDto> CreateAsync(TicketPurchaseCompletedOrderCreateRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<TicketPurchaseCompletedOrderDetailDto> UpdateAsync(TicketPurchaseCompletedOrderUpdateRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<TicketPurchaseCompletedOrderDetailDto> GetByIdAsync(TicketPurchaseCompletedOrderGetByIdRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<PagedResult<TicketPurchaseCompletedOrderListItemDto>> PagedListAsync(TicketPurchaseCompletedOrderSearchRequestDto request, CancellationToken cancellationToken = new());
}