using Gronio.Database.Abstraction;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.Admin;

namespace TicketSystem.DataAccess.Contract.Repository;

public interface IAdminRepository : IRepository
{
    ValueTask<bool> AddAsync(Admin entity, CancellationToken cancellationToken = default);
    ValueTask<bool> UpdateAsync(Admin entity, CancellationToken cancellationToken = default);
    ValueTask<AdminDetailDto> GetByIdAsync(AdminGetByIdRequestDto request, CancellationToken cancellationToken = default);
    ValueTask<PagedResult<AdminListItemDto>> PagedListAsync(AdminSearchRequestDto request, CancellationToken cancellationToken = default);
    ValueTask<bool> ToggleStatusAsync(AdminGetByIdRequestDto request, CancellationToken cancellationToken = default);
    ValueTask<AdminDetailDto> LoginAsync(string userName, string passwordHash, CancellationToken cancellationToken = default);
    ValueTask<bool> ControlAndGetMultipleRecordFromInsert(AdminCreateRequestDto request);
    ValueTask<bool> ControlAndGetMultipleRecordFromUpdate(AdminUpdateRequestDto request);
}