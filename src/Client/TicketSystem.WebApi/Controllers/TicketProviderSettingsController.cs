using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.Business.Contract.Services;
using TicketSystem.Business.WebHelpers;
using TicketSystem.Common.Constants;
using TicketSystem.Dto.ExternalApiResponseModels;
using TicketSystem.Dto.TicketProviderSetting;

namespace TicketSystem.WebApi.Controllers;

[ApiController]
[Route(ApplicationConstants.TicketProviderSettingsControllerBaseRoute)]
public sealed class TicketProviderSettingsController : BaseController
{
    private readonly ITicketProviderSettingsManager _ticketProviderSettingsManager;
    private readonly IPassoLigService _passoLigService;

    public TicketProviderSettingsController(ITicketProviderSettingsManager ticketProviderSettingsManager, IPassoLigService passoLigService)
    {
        _ticketProviderSettingsManager = ticketProviderSettingsManager;
        _passoLigService = passoLigService;
    }

    [HttpPut]
    public async ValueTask<bool> UpdateAsync([FromBody] TicketProviderSettingUpdateRequestDto request, CancellationToken cancellationToken = new())
    {
        return await _ticketProviderSettingsManager.UpdateAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpGet("get-provider-settings")]
    public async ValueTask<Dictionary<string, string>> GetProviderSettingsAsync([FromQuery] TicketProviderSettingGetByProviderRequestDto request, CancellationToken cancellationToken = new())
    {
        return await _ticketProviderSettingsManager.GetProviderSettingsAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpGet("get-provider-settings-detail")]
    public async ValueTask<TicketProviderSettingDetailDto> GetProviderSettingDetailAsync([FromQuery] TicketProviderSettingGetByKeyRequestDto request, CancellationToken cancellationToken = new())
    {
        return await _ticketProviderSettingsManager.GetProviderSettingDetailAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpPost("refresh-passolig-main-token")]
    public async ValueTask<bool> RefreshPassoLigMainTokenAsync(CancellationToken cancellationToken = new())
    {
        return await _passoLigService.GenerateMainTokenRequestAsync(cancellationToken).ConfigureAwait(false);
    }

    [HttpPost("validate-passolig-gsm-code")]
    public async ValueTask<bool> ValidatePassoLigGsmCodeAsync(PassoLigMainRequestGsmApproveRequestDto request, CancellationToken cancellationToken = new())
    {
        return await _passoLigService.ApproveMainTokenAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [AllowAnonymous]
    [HttpGet("login")]
    public async ValueTask<PassoLigLoginResponseModel> LoginPassoLigAsync(int accountId,
        CancellationToken cancellationToken = new())
    {
        return await _passoLigService.GetOrCreateCustomerPassoLigTokenDetailAsync(new PassoLigLoginRequestModel
        {
            AccountId = accountId
        }, cancellationToken);
    }
}