using Gronio.Database.Abstraction;
using TicketSystem.DataAccess.Context;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.TicketAccountDefinitionSettings;

namespace TicketSystem.DataAccess.Repository;

internal sealed class TicketAccountDefinitionSettingRepository : RepositoryFactory<TicketAccountDefinitionSetting, int>, ITicketAccountDefinitionSettingRepository
{
    public TicketAccountDefinitionSettingRepository(TicketAutomationSystemDbContext context, IServiceProvider serviceProvider)
        : base(context, serviceProvider)
    {
    }

    public async ValueTask<bool> CreateAsync(TicketAccountDefinitionSetting entity, CancellationToken cancellationToken = new())
    {
        InsertRepository.AddAsync(entity, cancellationToken);
        var result = await InsertRepository.SaveAsync(cancellationToken);
        return result > 0;
    }

    public async ValueTask<bool> UpdateAsync(TicketAccountDefinitionSetting entity, CancellationToken cancellationToken = new())
    {
        UpdateRepository.Update(entity);
        var result = await UpdateRepository.SaveAsync(cancellationToken);
        return result > 0;
    }

    public async ValueTask<List<TicketAccountDefinitionSettingListItemDto>> GetProviderSettingsAsync(TicketAccountDefinitionSettingGetByAccountIdRequestDto request,
        CancellationToken cancellationToken = new())
    {
        return await QueryRepository.GetListAsync<TicketAccountDefinitionSettingListItemDto>(x => x.TicketAccountDefinitionId == request.AccountId, cancellationToken: cancellationToken);
    }
}