using Gronio.Database.Abstraction;
using Gronio.Utility.Helper.Validation;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.Business.Managers.Main;
using TicketSystem.Business.Validators;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.Dto.EventLogs;
using TicketSystem.Dto.TicketPurchaseOrders;
using TicketSystem.Enums;

namespace TicketSystem.Business.Managers;

internal sealed class CccTicketPurchaseOrderManager : TicketPurchaseOrderManager
{
    private readonly IEventLogManager _eventLogManager;

    public CccTicketPurchaseOrderManager(ITicketPurchaseOrderRepository ticketPurchaseOrderRepository, IEventLogManager eventLogManager)
        : base(ticketPurchaseOrderRepository)
    {
        _eventLogManager = eventLogManager;
    }

    public override async ValueTask<TicketPurchaseOrderDetailDto> CreateAsync(TicketPurchaseOrderCreateRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TicketPurchaseOrderCreateValidator>(request);

        var result = await base.CreateAsync(request, cancellationToken);

        var eventLogRequest = new EventLogCreateRequestDto
        {
            AdminId = request.AdminId,
            IpAddress = request.IpAddress,
            Message = $"Yeni bilet satış emri eklendi => {request.Name}",
            Type = EventLogTypeEnum.Information,
        };

        await _eventLogManager.AddEventLogAsync(eventLogRequest, cancellationToken);


        return result;
    }

    public override ValueTask<TicketPurchaseOrderDetailDto> GetByIdAsync(TicketPurchaseOrderGetByIdRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TicketPurchaseOrderGetByIdValidator>(request);

        return base.GetByIdAsync(request, cancellationToken);
    }

    public override async ValueTask<TicketPurchaseOrderDetailDto> UpdateAsync(TicketPurchaseOrderUpdateRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TicketPurchaseOrderUpdateValidator>(request);

        var result = await base.UpdateAsync(request, cancellationToken);

        var eventLogRequest = new EventLogCreateRequestDto
        {
            AdminId = request.AdminId,
            IpAddress = request.IpAddress,
            Message = $"Bilet Satış emri güncellendi=> {request.Name}",
            Type = EventLogTypeEnum.Information,
        };

        await _eventLogManager.AddEventLogAsync(eventLogRequest, cancellationToken);

        return result;
    }

    public override ValueTask<PagedResult<TicketPurchaseOrderListItemDto>> PagedListAsync(TicketPurchaseOrderSearchRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TicketPurchaseOrderPagedListValidator>(request);

        return base.PagedListAsync(request, cancellationToken);
    }
}