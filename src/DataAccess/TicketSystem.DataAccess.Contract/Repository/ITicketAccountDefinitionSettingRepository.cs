using Gronio.Database.Abstraction;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.TicketAccountDefinitionSettings;

namespace TicketSystem.DataAccess.Contract.Repository;

public interface ITicketAccountDefinitionSettingRepository : IRepository
{
    ValueTask<bool> CreateAsync(TicketAccountDefinitionSetting entity, CancellationToken cancellationToken = new());
    ValueTask<bool> UpdateAsync(TicketAccountDefinitionSetting entity, CancellationToken cancellationToken = new());
    ValueTask<List<TicketAccountDefinitionSettingListItemDto>> GetProviderSettingsAsync(TicketAccountDefinitionSettingGetByAccountIdRequestDto request, CancellationToken cancellationToken = new());
}