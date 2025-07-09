using Gronio.Database.Abstraction;
using TicketSystem.DataAccess.Context;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.Admin;

namespace TicketSystem.DataAccess.Repository;

internal sealed class AdminLoginLogRepository : RepositoryFactory<AdminLogin, int>, IAdminLoginLogRepository
{
    public AdminLoginLogRepository(TicketAutomationSystemDbContext context, IServiceProvider serviceProvider)
        : base(context, serviceProvider)
    {
    }

    public async ValueTask<bool> AddAsync(AdminLogin entity, CancellationToken cancellationToken = new())
    {
        InsertRepository.AddAsync(entity, cancellationToken);
        var result = await InsertRepository.SaveAsync(cancellationToken);
        return result > 0;
    }

    public async ValueTask<List<AdminLoginListItemDto>> GetAdminLoginsAsync(short adminId, CancellationToken cancellationToken = new())
    {
        return await QueryRepository.GetListAsync<AdminLoginListItemDto>(x => x.IsSuccess && x.AdminId == adminId, x => x.OrderByDescending(y => y.CreatedTime), cancellationToken: cancellationToken);
    }

    public async ValueTask<AdminLoginListItemDto> GetAdminLastLoginAsync(short adminId, CancellationToken cancellationToken = new())
    {
        var result = await QueryRepository.GetListAsync<AdminLoginListItemDto>(x => x.IsSuccess && x.AdminId == adminId, x => x.OrderByDescending(y => y.CreatedTime), topRecords: 1, cancellationToken);

        return result.FirstOrDefault();
    }
}