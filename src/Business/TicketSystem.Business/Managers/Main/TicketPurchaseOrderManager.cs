using Gronio.Database.Abstraction;
using Mapster;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.TicketPurchaseOrders;

namespace TicketSystem.Business.Managers.Main;

internal class TicketPurchaseOrderManager : ITicketPurchaseOrderManager
{
    protected readonly ITicketPurchaseOrderRepository TicketPurchaseOrderRepository;

    public TicketPurchaseOrderManager(ITicketPurchaseOrderRepository ticketPurchaseOrderRepository)
    {
        TicketPurchaseOrderRepository = ticketPurchaseOrderRepository;
    }

    public virtual async ValueTask<TicketPurchaseOrderDetailDto> CreateAsync(TicketPurchaseOrderCreateRequestDto request,
        CancellationToken cancellationToken = new())
    {
        var entity = request.Adapt<TicketPurchaseOrder>();

        var result = await TicketPurchaseOrderRepository.CreateAsync(entity, cancellationToken);

        return entity.Adapt<TicketPurchaseOrderDetailDto>();
    }

    public virtual async ValueTask<TicketPurchaseOrderDetailDto> UpdateAsync(TicketPurchaseOrderUpdateRequestDto request,
        CancellationToken cancellationToken = new())
    {
        var entity = request.Adapt<TicketPurchaseOrder>();

        var result = await TicketPurchaseOrderRepository.UpdateAsync(entity, cancellationToken);

        return entity.Adapt<TicketPurchaseOrderDetailDto>();
    }

    public virtual ValueTask<PagedResult<TicketPurchaseOrderListItemDto>> PagedListAsync(TicketPurchaseOrderSearchRequestDto request,
        CancellationToken cancellationToken = new())
    {
        return TicketPurchaseOrderRepository.PagedListAsync(request, cancellationToken);
    }

    public virtual async ValueTask<TicketPurchaseOrderDetailDto> GetByIdAsync(TicketPurchaseOrderGetByIdRequestDto request,
        CancellationToken cancellationToken = new())
    {
        return await TicketPurchaseOrderRepository.GetByIdAsync(request, cancellationToken);
    }
}