using Gronio.Database.Abstraction;
using TicketSystem.DataAccess.Context;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.SystemSettings;

namespace TicketSystem.DataAccess.Repository;

internal sealed class SystemSettingsRepository : RepositoryFactory<SystemSettings, byte>, ISystemSettingsRepository
{
    public SystemSettingsRepository(TicketAutomationSystemDbContext context, IServiceProvider serviceProvider)
        : base(context, serviceProvider)
    {
    }

    public async ValueTask<bool> UpdateSystemSettings(SystemSettings entity, CancellationToken cancellation = new())
    {
        UpdateRepository.Update(entity);
        var result = await UpdateRepository.SaveAsync(cancellation);

        return result > 0;
    }

    public async ValueTask<SystemSettingsDetailDto> GetSystemSettings(CancellationToken cancellation = new())
    {
        return await QueryRepository.GetFirstOrDefaultAsync<SystemSettingsDetailDto>(x => x.Id == 1, cancellationToken: cancellation);
    }
}