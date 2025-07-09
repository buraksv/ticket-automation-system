using Gronio.Database.Abstraction;
using Gronio.Utility.Helper.Core.BusinessEngine;
using TicketSystem.Dto.TicketPurchaseOrders;

namespace TicketSystem.Business.Contract.Managers;

public interface ITicketPurchaseOrderManager : IBusinessEngine
{
    ValueTask<TicketPurchaseOrderDetailDto> CreateAsync(TicketPurchaseOrderCreateRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<TicketPurchaseOrderDetailDto> UpdateAsync(TicketPurchaseOrderUpdateRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<PagedResult<TicketPurchaseOrderListItemDto>> PagedListAsync(TicketPurchaseOrderSearchRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<TicketPurchaseOrderDetailDto> GetByIdAsync(TicketPurchaseOrderGetByIdRequestDto request, CancellationToken cancellationToken = new());
}