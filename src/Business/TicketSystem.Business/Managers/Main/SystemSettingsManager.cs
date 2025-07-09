using Mapster;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.SystemSettings;

namespace TicketSystem.Business.Managers.Main;

internal class SystemSettingsManager : ISystemSettingsManager
{
    protected readonly ISystemSettingsRepository SystemSettingsRepository;

    public SystemSettingsManager(ISystemSettingsRepository systemSettingsRepository)
    {
        SystemSettingsRepository = systemSettingsRepository;
    }

    public virtual async ValueTask<SystemSettingsDetailDto> UpdateAsync(SystemSettingsUpdateRequestDto request,
        CancellationToken cancellationToken = new())
    {
        var entity = request.Adapt<SystemSettings>();

        await SystemSettingsRepository.UpdateSystemSettings(entity, cancellationToken);

        return entity.Adapt<SystemSettingsDetailDto>();
    }

    public virtual ValueTask<SystemSettingsDetailDto> LoadSettingsAsync(CancellationToken cancellationToken = new())
    {
        return SystemSettingsRepository.GetSystemSettings(cancellationToken);
    }
}