using Gronio.Database.Abstraction;
using TicketSystem.DataAccess.Context;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.TicketProviderSetting;

namespace TicketSystem.DataAccess.Repository;

internal sealed class TicketProviderSettingRepository : RepositoryFactory<TicketProviderSetting, int>, ITicketProviderSettingRepository
{
    public TicketProviderSettingRepository(TicketAutomationSystemDbContext context, IServiceProvider serviceProvider)
        : base(context, serviceProvider)
    {
    }

    public async ValueTask<bool> CreateAsync(TicketProviderSetting entity, CancellationToken cancellationToken = new())
    {
        InsertRepository.AddAsync(entity, cancellationToken);
        var result = await InsertRepository.SaveAsync(cancellationToken);
        return result > 0;
    }

    public async ValueTask<bool> UpdateAsync(TicketProviderSetting entity, CancellationToken cancellationToken = new())
    {
        UpdateRepository.Update(entity);
        var result = await UpdateRepository.SaveAsync(cancellationToken);

        return result > 0;
    }

    public async ValueTask<List<TicketProviderSettingListItemDto>> GetProviderSettingsAsync(TicketProviderSettingGetByProviderRequestDto request, CancellationToken cancellationToken = new())
    {
        return await QueryRepository.GetListAsync<TicketProviderSettingListItemDto>(x => x.Provider == request.Provider,
            cancellationToken: cancellationToken);
    }

    public async ValueTask<TicketProviderSettingDetailDto> GetProviderSettingDetailAsync(TicketProviderSettingGetByKeyRequestDto request, CancellationToken cancellationToken = new())
    {
        return await QueryRepository.GetFirstOrDefaultAsync<TicketProviderSettingDetailDto>(x => x.Provider == request.Provider && x.Key == request.Key, cancellationToken: cancellationToken);
    }
}