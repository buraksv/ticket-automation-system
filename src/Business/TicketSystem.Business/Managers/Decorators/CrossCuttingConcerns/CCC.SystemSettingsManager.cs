using Gronio.Utility.Helper.Validation;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.Business.Managers.Main;
using TicketSystem.Business.Validators;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.Dto.EventLogs;
using TicketSystem.Dto.SystemSettings;
using TicketSystem.Enums;

namespace TicketSystem.Business.Managers;

internal sealed class CccSystemSettingsManager : SystemSettingsManager
{
    private readonly IEventLogManager _eventLogManager;

    public CccSystemSettingsManager(ISystemSettingsRepository systemSettingsRepository, IEventLogManager eventLogManager)
        : base(systemSettingsRepository)
    {
        _eventLogManager = eventLogManager;
    }

    public override ValueTask<SystemSettingsDetailDto> LoadSettingsAsync(CancellationToken cancellationToken = new())
    {
        return base.LoadSettingsAsync(cancellationToken);
    }

    public override async ValueTask<SystemSettingsDetailDto> UpdateAsync(SystemSettingsUpdateRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<SystemSettingsUpdateValidator>(request);

        var result = await base.UpdateAsync(request, cancellationToken);

        var eventLogRequest = new EventLogCreateRequestDto
        {
            AdminId = request.AdminId,
            IpAddress = request.IpAddress,
            Message = $"Sistem Ayarları Güncellendi",
            Type = EventLogTypeEnum.Information,
        };

        await _eventLogManager.AddEventLogAsync(eventLogRequest, cancellationToken);

        return result;
    }
}