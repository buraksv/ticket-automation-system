using Gronio.Database.Abstraction;
using Mapster;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.TicketPurchaseCompletedOrders;

namespace TicketSystem.Business.Managers.Main;

internal class TicketPurchaseCompletedOrderManager : ITicketPurchaseCompletedOrderManager
{
    protected readonly ITicketPurchaseCompletedOrderRepository TicketPurchaseCompletedOrderRepository;

    public TicketPurchaseCompletedOrderManager(ITicketPurchaseCompletedOrderRepository ticketPurchaseCompletedOrderRepository)
    {
        TicketPurchaseCompletedOrderRepository = ticketPurchaseCompletedOrderRepository;
    }

    public virtual async ValueTask<TicketPurchaseCompletedOrderDetailDto> CreateAsync(TicketPurchaseCompletedOrderCreateRequestDto request,
        CancellationToken cancellationToken = new())
    {
        var entity = request.Adapt<TicketPurchaseCompletedOrder>();

        var result = await TicketPurchaseCompletedOrderRepository.CreateAsync(entity, cancellationToken);

        return entity.Adapt<TicketPurchaseCompletedOrderDetailDto>();
    }

    public virtual async ValueTask<TicketPurchaseCompletedOrderDetailDto> UpdateAsync(TicketPurchaseCompletedOrderUpdateRequestDto request,
        CancellationToken cancellationToken = new())
    {
        var entity = request.Adapt<TicketPurchaseCompletedOrder>();

        var result = await TicketPurchaseCompletedOrderRepository.UpdateAsync(entity, cancellationToken);

        return entity.Adapt<TicketPurchaseCompletedOrderDetailDto>();
    }

    public virtual async ValueTask<TicketPurchaseCompletedOrderDetailDto> GetByIdAsync(TicketPurchaseCompletedOrderGetByIdRequestDto request,
        CancellationToken cancellationToken = new())
    {
        return await TicketPurchaseCompletedOrderRepository.GetByIdAsync(request, cancellationToken);
    }

    public virtual ValueTask<PagedResult<TicketPurchaseCompletedOrderListItemDto>> PagedListAsync(TicketPurchaseCompletedOrderSearchRequestDto request,
        CancellationToken cancellationToken = new())
    {
        return TicketPurchaseCompletedOrderRepository.PagedListAsync(request, cancellationToken);
    }
}