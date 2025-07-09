using Gronio.Utility.Helper.Core.BusinessEngine;
using TicketSystem.Dto.SystemSettings;

namespace TicketSystem.Business.Contract.Managers;

public interface ISystemSettingsManager : IBusinessEngine
{
    ValueTask<SystemSettingsDetailDto> UpdateAsync(SystemSettingsUpdateRequestDto request, CancellationToken cancellationToken = new());
    ValueTask<SystemSettingsDetailDto> LoadSettingsAsync(CancellationToken cancellationToken = new());
}