using Gronio.Database.Abstraction;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Dto.SystemSettings;

namespace TicketSystem.DataAccess.Contract.Repository;

public interface ISystemSettingsRepository : IRepository
{
    ValueTask<bool> UpdateSystemSettings(SystemSettings request, CancellationToken cancellation = new());
    ValueTask<SystemSettingsDetailDto> GetSystemSettings(CancellationToken cancellation = new());
}