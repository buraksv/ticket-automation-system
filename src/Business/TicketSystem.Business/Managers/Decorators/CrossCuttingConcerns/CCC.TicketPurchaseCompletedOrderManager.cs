using Gronio.Database.Abstraction;
using Gronio.Utility.Helper.Validation;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.Business.Managers.Main;
using TicketSystem.Business.Validators;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.Dto.TicketPurchaseCompletedOrders;

namespace TicketSystem.Business.Managers;

internal sealed class CccTicketPurchaseCompletedOrderManager : TicketPurchaseCompletedOrderManager
{
    private readonly IEventLogManager _eventLogManager;

    public CccTicketPurchaseCompletedOrderManager(ITicketPurchaseCompletedOrderRepository ticketPurchaseCompletedOrderRepository, IEventLogManager eventLogManager)
        : base(ticketPurchaseCompletedOrderRepository)
    {
        _eventLogManager = eventLogManager;
    }

    public override async ValueTask<TicketPurchaseCompletedOrderDetailDto> CreateAsync(TicketPurchaseCompletedOrderCreateRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TicketPurchaseCompletedOrderCreateValidator>(request);

        var result = await base.CreateAsync(request, cancellationToken); 

        return result;
    }

    public override ValueTask<TicketPurchaseCompletedOrderDetailDto> GetByIdAsync(TicketPurchaseCompletedOrderGetByIdRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TicketPurchaseCompletedOrderGetByIdValidator>(request);

        return base.GetByIdAsync(request, cancellationToken);
    }

    public override ValueTask<PagedResult<TicketPurchaseCompletedOrderListItemDto>> PagedListAsync(TicketPurchaseCompletedOrderSearchRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TicketPurchaseCompletedOrderPagedListValidator>(request);

        return base.PagedListAsync(request, cancellationToken);
    }

    public override async ValueTask<TicketPurchaseCompletedOrderDetailDto> UpdateAsync(TicketPurchaseCompletedOrderUpdateRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TicketPurchaseCompletedOrderUpdateValidator>(request);

        var result = await base.UpdateAsync(request, cancellationToken);

        return result;
    }
}