using Gronio.Database.EntityFramework.PostgreSql;
using Microsoft.EntityFrameworkCore;
using TicketSystem.DataAccess.Context.Mappings.PostgreSql;

namespace TicketSystem.DataAccess.Context;

public sealed class TicketAutomationSystemDbContext : PostgreSqlDbContextBase
{
    public TicketAutomationSystemDbContext(DbContextOptions<TicketAutomationSystemDbContext> options, IServiceProvider serviceProvider)
        : base(options, serviceProvider)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AdminLoginMappings());
        modelBuilder.ApplyConfiguration(new AdminDatabaseMappings());
        modelBuilder.ApplyConfiguration(new EventLogMappings());
        modelBuilder.ApplyConfiguration(new SystemSettingsDatabaseMappings());
        modelBuilder.ApplyConfiguration(new TeamDatabaseMappings());
        modelBuilder.ApplyConfiguration(new TicketAccountDefinitionDatabaseMappings());
        modelBuilder.ApplyConfiguration(new TicketPurchaseCompletedOrderDatabaseMappings());
        modelBuilder.ApplyConfiguration(new TicketPurchaseOrderAccountDatabaseMappings());
        modelBuilder.ApplyConfiguration(new TicketPurchaseOrderDatabaseMappings());
        modelBuilder.ApplyConfiguration(new TicketPurchaseOrderSystemLogDatabaseMappings());
        modelBuilder.ApplyConfiguration(new TicketPlaceConfigurationsMappings());
        modelBuilder.ApplyConfiguration(new TicketPlaceMappings());
        modelBuilder.ApplyConfiguration(new TicketProviderSettingMappings());
        modelBuilder.ApplyConfiguration(new TicketAccountDefinitionSettingDatabaseMappings());

        base.OnModelCreating(modelBuilder);
    }
}