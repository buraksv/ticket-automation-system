using TicketSystem.Business.Contract.Managers;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.TicketProviderSetting;

namespace TicketSystem.Business.Managers.Main;

internal class TicketProviderSettingsManager : ITicketProviderSettingsManager
{
    protected readonly ITicketProviderSettingRepository TicketProviderSettingRepository;

    public TicketProviderSettingsManager(ITicketProviderSettingRepository ticketProviderSettingRepository)
    {
        TicketProviderSettingRepository = ticketProviderSettingRepository;
    }

    public virtual async ValueTask<bool> UpdateAsync(TicketProviderSettingUpdateRequestDto request, CancellationToken cancellationToken = new())
    {
        var settingControl = await this.TicketProviderSettingRepository.GetProviderSettingDetailAsync(new TicketProviderSettingGetByKeyRequestDto
        {
            Key = request.Key,
            Provider = request.Provider,
        }, cancellationToken);

        if (settingControl != null)
        {
            var entity = new TicketProviderSetting
            {
                Id = settingControl.Id,
                Key = settingControl.Key,
                Provider = settingControl.Provider,
                Value = settingControl.Value,
            };

            return await this.TicketProviderSettingRepository.UpdateAsync(entity, cancellationToken);
        }
        else
        {
            var entity = new TicketProviderSetting
            {
                Key = request.Key,
                Provider = request.Provider,
                Value = request.Value,
            };

            return await this.TicketProviderSettingRepository.CreateAsync(entity, cancellationToken);
        }
    }

    public virtual async ValueTask<Dictionary<string, string>> GetProviderSettingsAsync(TicketProviderSettingGetByProviderRequestDto request, CancellationToken cancellationToken = new())
    {
        var data = await TicketProviderSettingRepository.GetProviderSettingsAsync(request, cancellationToken);

        return data.ToDictionary(x => x.Key, y => y.Value);
    }

    public virtual async ValueTask<TicketProviderSettingDetailDto> GetProviderSettingDetailAsync(TicketProviderSettingGetByKeyRequestDto request, CancellationToken cancellationToken = new())
    {
        return await TicketProviderSettingRepository.GetProviderSettingDetailAsync(request, cancellationToken);
    }
}