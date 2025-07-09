using Gronio.Database.Abstraction;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.Business.WebHelpers;
using TicketSystem.Common.Constants;
using TicketSystem.Dto.Admin;

namespace TicketSystem.WebApi.Controllers;

[ApiController]
[Route(ApplicationConstants.AdminControllerBaseRoute)]
public sealed class AdminController : BaseController
{
    private readonly IAdminManager _adminManager;

    public AdminController(IAdminManager adminManager)
    {
        _adminManager = adminManager;
    }

    [HttpPost]
    public async ValueTask<AdminDetailDto> CreateAsync(AdminCreateRequestDto request, CancellationToken cancellationToken = new())
    {
        request.AdminId = AdminId;
        request.IpAddress = IpAddress;

        return await _adminManager.CreateAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpPut]
    public async ValueTask<AdminDetailDto> UpdateAsync(AdminUpdateRequestDto request, CancellationToken cancellationToken = new())
    {
        request.AdminId = AdminId;
        request.IpAddress = IpAddress;

        return await _adminManager.UpdateAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpGet("{id:int}")]
    public async ValueTask<AdminDetailDto> GetByIdAsync([FromRoute] AdminGetByIdRequestDto request, CancellationToken cancellationToken = new())
    {
        return await _adminManager.GetByIdAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpPost(ApplicationConstants.SearchEndpoint)]
    public async ValueTask<PagedResult<AdminListItemDto>> PagedListAsync(AdminSearchRequestDto request,
        CancellationToken cancellationToken = new())
    {
        return await _adminManager.PagedListAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpPatch("change-password")]
    public async ValueTask<bool> ChangePasswordAsync(AdminChangePasswordRequestDto request, CancellationToken cancellationToken = new())
    {
        return await _adminManager.ChangePasswordAsync(request, cancellationToken).ConfigureAwait(false);
    }

    [HttpPatch("{id:int}/toggle-status")]
    public async ValueTask<bool> ToggleStatusAsync([FromRoute] AdminGetByIdRequestDto request,
        CancellationToken cancellationToken = new())
    {
        return await _adminManager.ToggleStatusAsync(request, AdminId, IpAddress, cancellationToken).ConfigureAwait(false);
    }
}