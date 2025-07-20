using Gronio.Database.Abstraction;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.TicketProviderSetting;

namespace TicketSystem.DataAccess.Contract.Repository;

public interface ITicketProviderSettingRepository : IRepository
{
    ValueTask<bool> CreateAsync(TicketProviderSetting entity, CancellationToken cancellationToken = new());
    ValueTask<bool> UpdateAsync(TicketProviderSetting entity, CancellationToken cancellationToken = new());
    ValueTask<List<TicketProviderSettingListItemDto>> GetProviderSettingsAsync(TicketProviderSettingGetByProviderRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<TicketProviderSettingDetailDto> GetProviderSettingDetailAsync(TicketProviderSettingGetByKeyRequestDto request, CancellationToken cancellationToken = new());
}