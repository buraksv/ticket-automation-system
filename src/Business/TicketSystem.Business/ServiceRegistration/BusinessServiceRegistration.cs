using Gronio.Utility.Extensions;
using Microsoft.Extensions.DependencyInjection;
using TicketSystem.Business.BusinessRules;
using TicketSystem.Business.Contract.BusinessRules;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.Business.Contract.Services;
using TicketSystem.Business.Managers;
using TicketSystem.Business.Services;

namespace TicketSystem.Business.ServiceRegistration;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services,
        ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        services.AddService<IAdminBusinessRules, AdminBusinessRules>(lifetime);

        services.AddService<IAdminManager, CccAdminManager>(lifetime);
        services.AddService<IEventLogManager, CccEventLogManager>(lifetime);
        services.AddService<ISystemSettingsManager, CccSystemSettingsManager>(lifetime);
        services.AddService<ITeamManager, CccTeamManager>(lifetime);
        services.AddService<ITicketPlaceManager, CccTicketPlaceManager>(lifetime);
        services.AddService<ITicketAccountDefinitionManager, CccTicketAccountDefinitionManager>(lifetime);
        services.AddService<ITicketPurchaseCompletedOrderManager, CccTicketPurchaseCompletedOrderManager>(lifetime);
        services.AddService<ITicketPurchaseOrderAccountManager, CccTicketPurchaseOrderAccountManager>(lifetime);
        services.AddService<ITicketPurchaseOrderManager, CccTicketPurchaseOrderManager>(lifetime);
        services.AddService<ITicketPurchaseOrderSystemLogManager, CccTicketPurchaseOrderSystemLogManager>(lifetime);
        services.AddService<ITicketProviderSettingsManager, CccTicketProviderSettingsManager>(lifetime);


        services.AddService<IPassoLigService, PassoLigService>(lifetime);

        return services;
    }
}