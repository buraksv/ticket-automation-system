using Microsoft.AspNetCore.Mvc;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.Business.WebHelpers;
using TicketSystem.Common.Constants;
using TicketSystem.Dto.SystemSettings;

namespace TicketSystem.WebApi.Controllers;

[ApiController]
[Route(ApplicationConstants.SystemSettingsControllerBaseRoute)]
public sealed class SystemSettingsController : BaseController
{
    private readonly ISystemSettingsManager _systemSettingsManager;

    public SystemSettingsController(ISystemSettingsManager systemSettingsManager)
    {
        _systemSettingsManager = systemSettingsManager;
    }

    [HttpPut]
    public async ValueTask<SystemSettingsDetailDto> UpdateAsync(SystemSettingsUpdateRequestDto request,
        CancellationToken cancellationToken = new())
    {
        request.AdminId = AdminId;
        request.IpAddress = IpAddress;

        return await _systemSettingsManager.UpdateAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpGet]
    public async ValueTask<SystemSettingsDetailDto> LoadSettingsAsync(CancellationToken cancellationToken = new())
    {
        return await _systemSettingsManager.LoadSettingsAsync(cancellationToken).ConfigureAwait(false);
    }
}