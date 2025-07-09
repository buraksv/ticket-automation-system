using Gronio.Database.Abstraction;
using Gronio.Utility.Helper.Validation;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.Business.Managers.Main;
using TicketSystem.Business.Validators;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.Dto.EventLogs;
using TicketSystem.Dto.TicketAccountDefinitions;
using TicketSystem.Enums;

namespace TicketSystem.Business.Managers;

internal sealed class CccTicketAccountDefinitionManager : TicketAccountDefinitionManager
{
    private readonly IEventLogManager _eventLogManager;

    public CccTicketAccountDefinitionManager(ITicketAccountDefinitionRepository ticketAccountDefinitionRepository, IEventLogManager eventLogManager)
        : base(ticketAccountDefinitionRepository)
    {
        _eventLogManager = eventLogManager;
    }

    public override async ValueTask<TicketAccountDefinitionDetailDto> CreateAsync(TicketAccountDefinitionCreateRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TicketAccountDefinitionCreateValidator>(request);

        var result = await base.CreateAsync(request, cancellationToken);

        var eventLogRequest = new EventLogCreateRequestDto
        {
            AdminId = request.AdminId,
            IpAddress = request.IpAddress,
            Message = $"Bilet Hesap Tanımı eklendi => {request.AccountType.ToString()} / {request.Name} {request.Surname}",
            Type = EventLogTypeEnum.Information,
        };

        await _eventLogManager.AddEventLogAsync(eventLogRequest, cancellationToken);

        return result;
    }

    public override ValueTask<TicketAccountDefinitionDetailDto> GetByIdAsync(TicketAccountDefinitionGetByIdRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TicketAccountDefinitionGetByIdValidator>(request);

        return base.GetByIdAsync(request, cancellationToken);
    }

    public override ValueTask<PagedResult<TicketAccountDefinitionListItemDto>> PagedListAsync(TicketAccountDefinitionSearchRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TicketAccountDefinitionPagedListValidator>(request);

        return base.PagedListAsync(request, cancellationToken);
    }

    public override async ValueTask<bool> ToggleStatusAsync(TicketAccountDefinitionGetByIdRequestDto request, short adminId, string ipAddress, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TicketAccountDefinitionGetByIdValidator>(request);

        var result = await base.ToggleStatusAsync(request, adminId, ipAddress, cancellationToken);

        var eventLogRequest = new EventLogCreateRequestDto
        {
            AdminId = adminId,
            IpAddress = ipAddress,
            Message = $"Bilet Hesap Tanımı aktif/pasif durumu güncellendi => {request.Id.ToString()}",
            Type = EventLogTypeEnum.Information,
        };

        await _eventLogManager.AddEventLogAsync(eventLogRequest, cancellationToken);

        return result;
    }

    public override async ValueTask<TicketAccountDefinitionDetailDto> UpdateAsync(TicketAccountDefinitionUpdateRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TicketAccountDefinitionUpdateValidator>(request);

        var result = await base.UpdateAsync(request, cancellationToken);

        var eventLogRequest = new EventLogCreateRequestDto
        {
            AdminId = request.AdminId,
            IpAddress = request.IpAddress,
            Message = $"Bilet Hesap Tanımı güncellendi => {request.AccountType.ToString()} / {request.Name} {request.Surname}",
            Type = EventLogTypeEnum.Information,
        };

        await _eventLogManager.AddEventLogAsync(eventLogRequest, cancellationToken);

        return result;
    }
}