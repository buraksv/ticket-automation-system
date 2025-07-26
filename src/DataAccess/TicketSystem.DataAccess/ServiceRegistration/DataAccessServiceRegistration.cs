using Gronio.Utility.Extensions;
using Microsoft.Extensions.DependencyInjection;
using TicketSystem.DataAccess.Contract.Repository;
using TicketSystem.DataAccess.Repository;

namespace TicketSystem.DataAccess.ServiceRegistration;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        services.AddService<IAdminRepository, AdminRepository>(lifetime);
        services.AddService<IAdminLoginLogRepository, AdminLoginLogRepository>(lifetime);
        services.AddService<IEventLogRepository, EventLogRepository>(lifetime);
        services.AddService<ISystemSettingsRepository, SystemSettingsRepository>(lifetime);
        services.AddService<ITeamRepository, TeamRepository>(lifetime);
        services.AddService<ITicketPlaceRepository, TicketPlaceRepository>(lifetime);
        services.AddService<ITicketAccountDefinitionRepository, TicketAccountDefinitionRepository>(lifetime);
        services.AddService<ITicketPurchaseCompletedOrderRepository, TicketPurchaseCompletedOrderRepository>(lifetime);
        services.AddService<ITicketPurchaseOrderAccountRepository, TicketPurchaseOrderAccountRepository>(lifetime);
        services.AddService<ITicketPurchaseOrderRepository, TicketPurchaseOrderRepository>(lifetime);
        services.AddService<ITicketPurchaseOrderSystemLogRepository, TicketPurchaseOrderSystemLogRepository>(lifetime);
        services.AddService<ITicketProviderSettingRepository, TicketProviderSettingRepository>(lifetime);
        services.AddService<ITicketAccountDefinitionSettingRepository, TicketAccountDefinitionSettingRepository>(lifetime);

        return services;
    }
}