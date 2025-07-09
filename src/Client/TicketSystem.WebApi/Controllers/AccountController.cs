using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.Business.WebHelpers;
using TicketSystem.Common.Constants;
using TicketSystem.Dto.Admin;

namespace TicketSystem.WebApi.Controllers;

[ApiController]
[Route(ApplicationConstants.AccountControllerBaseRoute)]
public sealed class AccountController : BaseController
{
    private readonly IAdminManager _adminManager;

    public AccountController(IAdminManager adminManager)
    {
        _adminManager = adminManager;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async ValueTask<AdminLoginResponseDto> LoginAsync(AdminLoginRequestDto request, CancellationToken cancellationToken = new())
    {
        request.IpAddress = IpAddress;

        return await _adminManager.LoginAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpGet("logout")]
    public async ValueTask<bool> LogoutAsync(CancellationToken cancellationToken = new())
    {
        return await _adminManager.LogoutAsync(AdminId, cancellationToken).ConfigureAwait(false);
    }
}