using Gronio.Database.Abstraction;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.Admin;

namespace TicketSystem.DataAccess.Contract.Repository;

public interface IAdminLoginLogRepository : IRepository
{
    ValueTask<bool> AddAsync(AdminLogin entity, CancellationToken cancellationToken = new());
    ValueTask<List<AdminLoginListItemDto>> GetAdminLoginsAsync(short adminId, CancellationToken cancellationToken = new());
    ValueTask<AdminLoginListItemDto> GetAdminLastLoginAsync(short adminId, CancellationToken cancellationToken = new());
}