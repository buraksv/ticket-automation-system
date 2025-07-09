using Gronio.Database.Abstraction;
using Gronio.Utility.Helper.Core.BusinessEngine;
using TicketSystem.Dto.Admin;

namespace TicketSystem.Business.Contract.Managers;

public interface IAdminManager : IBusinessEngine
{
    ValueTask<AdminDetailDto> CreateAsync(AdminCreateRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<AdminDetailDto> UpdateAsync(AdminUpdateRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<AdminDetailDto> GetByIdAsync(AdminGetByIdRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<PagedResult<AdminListItemDto>> PagedListAsync(AdminSearchRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<bool> ToggleStatusAsync(AdminGetByIdRequestDto request, short adminId, string ipAddress, CancellationToken cancellationToken = new());
    ValueTask<bool> ChangePasswordAsync(AdminChangePasswordRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<AdminLoginResponseDto> LoginAsync(AdminLoginRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<bool> LogoutAsync(short adminId, CancellationToken cancellationToken = new());
}