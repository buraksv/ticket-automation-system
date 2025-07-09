using Gronio.Database.Abstraction;
using Gronio.Utility.Helper.Validation;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.Business.Managers.Main;
using TicketSystem.Business.Validators;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.Dto.EventLogs;
using TicketSystem.Dto.TicketPlaces;
using TicketSystem.Enums;

namespace TicketSystem.Business.Managers;

internal sealed class CccTicketPlaceManager : TicketPlaceManager
{
    private readonly IEventLogManager _eventLogManager;

    public CccTicketPlaceManager(ITicketPlaceRepository ticketPlaceRepository, IEventLogManager eventLogManager)
        : base(ticketPlaceRepository)
    {
        _eventLogManager = eventLogManager;
    }

    public override async ValueTask<TicketPlaceDetailDto> CreateAsync(TicketPlaceCreateRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TicketPlaceCreateValidator>(request);

        var result = await base.CreateAsync(request, cancellationToken);

        var eventLogRequest = new EventLogCreateRequestDto
        {
            AdminId = request.AdminId,
            IpAddress = request.IpAddress,
            Message = $"Bilet Etkinlik alanı eklendi => {request.PlaceName}",
            Type = EventLogTypeEnum.Information,
        };

        await _eventLogManager.AddEventLogAsync(eventLogRequest, cancellationToken);

        return result;
    }

    public override ValueTask<TicketPlaceDetailDto> GetByIdAsync(TicketPlaceGetByIdRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TicketPlaceGetByIdValidator>(request);

        return base.GetByIdAsync(request, cancellationToken);
    }

    public override async ValueTask<bool> ToggleStatusAsync(TicketPlaceGetByIdRequestDto request, short adminId, string ipAddress, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TicketPlaceGetByIdValidator>(request);

        var result = await base.ToggleStatusAsync(request, adminId, ipAddress, cancellationToken);

        var eventLogRequest = new EventLogCreateRequestDto
        {
            AdminId = adminId,
            IpAddress = ipAddress,
            Message = $"Bilet Etkinlik alanı aktif/pasif durumu güncellendi => {request.Id}",
            Type = EventLogTypeEnum.Information,
        };

        await _eventLogManager.AddEventLogAsync(eventLogRequest, cancellationToken);

        return result;
    }

    public override async ValueTask<TicketPlaceDetailDto> UpdateAsync(TicketPlaceUpdateRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TicketPlaceUpdateValidator>(request);

        var result = await base.UpdateAsync(request, cancellationToken);

        var eventLogRequest = new EventLogCreateRequestDto
        {
            AdminId = request.AdminId,
            IpAddress = request.IpAddress,
            Message = $"Bilet Etkinlik alanı güncellendi => {request.PlaceName}",
            Type = EventLogTypeEnum.Information,
        };

        await _eventLogManager.AddEventLogAsync(eventLogRequest, cancellationToken);

        return result;
    }

    public override ValueTask<PagedResult<TicketPlaceListItemDto>> PagedListAsync(TicketPlaceSearchRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TicketPlacePagedListValidator>(request);

        return base.PagedListAsync(request, cancellationToken);
    }
}