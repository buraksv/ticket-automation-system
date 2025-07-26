using Gronio.Utility.Helper.Validation;
using TicketSystem.Business.Managers.Main;
using TicketSystem.Business.Validators.TicketProviderSettingValidator;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.Dto.TicketProviderSetting;

namespace TicketSystem.Business.Managers;

internal sealed class CccTicketProviderSettingsManager : TicketProviderSettingsManager
{
    public CccTicketProviderSettingsManager(ITicketProviderSettingRepository ticketProviderSettingRepository)
    : base(ticketProviderSettingRepository)
    { }

    public override ValueTask<bool> UpdateAsync(TicketProviderSettingUpdateRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TicketProviderSettingUpdateValidator>(request);

        return base.UpdateAsync(request, cancellationToken);
    }

    public override ValueTask<Dictionary<string, string>> GetProviderSettingsAsync(TicketProviderSettingGetByProviderRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TicketProviderSettingGetByProviderValidator>(request);

        return base.GetProviderSettingsAsync(request, cancellationToken);
    }

    public override ValueTask<TicketProviderSettingDetailDto> GetProviderSettingDetailAsync(TicketProviderSettingGetByKeyRequestDto request, CancellationToken cancellationToken = new())
    {
        ValidationHelper.Validate<TicketProviderSettingGetDetailValidator>(request);

        return base.GetProviderSettingDetailAsync(request, cancellationToken);
    }
}