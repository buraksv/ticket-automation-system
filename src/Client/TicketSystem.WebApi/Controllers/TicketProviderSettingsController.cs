using Microsoft.AspNetCore.Mvc;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.Business.WebHelpers;
using TicketSystem.Common.Constants;
using TicketSystem.Dto.TicketProviderSetting;

namespace TicketSystem.WebApi.Controllers;

[ApiController]
[Route(ApplicationConstants.TicketProviderSettingsControllerBaseRoute)]
public sealed class TicketProviderSettingsController : BaseController
{
    private readonly ITicketProviderSettingsManager _ticketProviderSettingsManager;

    public TicketProviderSettingsController(ITicketProviderSettingsManager ticketProviderSettingsManager)
    {
        _ticketProviderSettingsManager = ticketProviderSettingsManager;
    }

    [HttpPut]
    public async ValueTask<bool> UpdateAsync([FromBody] TicketProviderSettingUpdateRequestDto request, CancellationToken cancellationToken = new())
    {
        return await _ticketProviderSettingsManager.UpdateAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpGet("get-provider-settings")]
    public async ValueTask<List<TicketProviderSettingListItemDto>> GetProviderSettingsAsync([FromQuery] TicketProviderSettingGetByProviderRequestDto request, CancellationToken cancellationToken = new())
    {
        return await _ticketProviderSettingsManager.GetProviderSettingsAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpGet("get-provider-settings-detail")]
    public async ValueTask<TicketProviderSettingDetailDto> GetProviderSettingDetailAsync([FromQuery] TicketProviderSettingGetByKeyRequestDto request, CancellationToken cancellationToken = new())
    {
        return await _ticketProviderSettingsManager.GetProviderSettingDetailAsync(request, cancellationToken).ConfigureAwait(false);
    }
}