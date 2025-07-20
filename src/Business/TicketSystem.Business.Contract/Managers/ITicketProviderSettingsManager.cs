using Gronio.Utility.Helper.Core.BusinessEngine;
using TicketSystem.Dto.TicketProviderSetting;

namespace TicketSystem.Business.Contract.Managers;

public interface ITicketProviderSettingsManager : IBusinessEngine
{
    ValueTask<bool> UpdateAsync(TicketProviderSettingUpdateRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<List<TicketProviderSettingListItemDto>> GetProviderSettingsAsync(TicketProviderSettingGetByProviderRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<TicketProviderSettingDetailDto> GetProviderSettingDetailAsync(TicketProviderSettingGetByKeyRequestDto request, CancellationToken cancellationToken = new());
}