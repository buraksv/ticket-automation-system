using Gronio.Utility.Helper.Validation;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.Business.Managers.Main;
using TicketSystem.Business.Validators;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.Dto.EventLogs;
using TicketSystem.Dto.TicketPurchaseOrderAccounts;
using TicketSystem.Enums;

namespace TicketSystem.Business.Managers;

internal sealed class CccTicketPurchaseOrderAccountManager : TicketPurchaseOrderAccountManager
{
    private readonly IEventLogManager _eventLogManager;

    public CccTicketPurchaseOrderAccountManager(ITicketPurchaseOrderAccountRepository ticketPurchaseOrderAccountRepository, IEventLogManager eventLogManager)
        : base(ticketPurchaseOrderAccountRepository)
    {
        _eventLogManager = eventLogManager;
    }

    public override async ValueTask<TicketPurchaseOrderAccountDetailDto> CreateAsync(TicketPurchaseOrderAccountCreateRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TicketPurchaseOrderAccountCreateValidator>(request);

        var result = await base.CreateAsync(request, cancellationToken);

        var eventLogRequest = new EventLogCreateRequestDto
        {
            AdminId = request.AdminId,
            IpAddress = request.IpAddress,
            Message = $"Bilet Siparişi içine yeni hesap eklendi => Hesap Id: {request.TicketAccountDefinitionId} // Order Id : {request.TicketPurchaseOrderId}",
            Type = EventLogTypeEnum.Information,
        };

        await _eventLogManager.AddEventLogAsync(eventLogRequest, cancellationToken);

        return result;
    }

    public override async ValueTask<bool> DeleteAsync(TicketPurchaseOrderAccountGetByIdRequestDto request, short adminId, string ipAddress, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TicketPurchaseOrderAccountGetByIdValidator>(request);

        var result = await base.DeleteAsync(request, adminId, ipAddress, cancellationToken);

        var eventLogRequest = new EventLogCreateRequestDto
        {
            AdminId = adminId,
            IpAddress = ipAddress,
            Message = $"Bilet Siparişinden hesap kaldırıldı => {request.Id}",
            Type = EventLogTypeEnum.Warning,
        };

        await _eventLogManager.AddEventLogAsync(eventLogRequest, cancellationToken);

        return result;
    }

    public override async ValueTask<TicketPurchaseOrderAccountDetailDto> UpdateAsync(TicketPurchaseOrderAccountUpdateRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TicketPurchaseOrderAccountUpdateValidator>(request);

        var result = await base.UpdateAsync(request, cancellationToken);

        var eventLogRequest = new EventLogCreateRequestDto
        {
            AdminId = request.AdminId,
            IpAddress = request.IpAddress,
            Message = $"Bilet Siparişi içindeki hesap tanımı güncellendi => Hesap Id: {request.TicketAccountDefinitionId} // Order Id : {request.TicketPurchaseOrderId}",
            Type = EventLogTypeEnum.Information,
        };

        await _eventLogManager.AddEventLogAsync(eventLogRequest, cancellationToken);

        return result;
    }

    public override ValueTask<List<TicketPurchaseOrderAccountListItemDto>> GetAccountsByOrderIdAsync(TicketPurchaseOrderAccountGetByOrderIdRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TicketPurchaseOrderAccountGetByOrderIdValidator>(request);

        return base.GetAccountsByOrderIdAsync(request, cancellationToken);
    }
}