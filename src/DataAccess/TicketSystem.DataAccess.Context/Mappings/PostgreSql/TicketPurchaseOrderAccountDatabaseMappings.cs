using System.Text.Json;
using Gronio.Database.EntityFramework.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketSystem.Common.Constants;
using TicketSystem.DataAccess.Entity;

namespace TicketSystem.DataAccess.Context.Mappings.PostgreSql;

internal sealed class TicketPurchaseOrderAccountDatabaseMappings : PostgreSqlRecordBaseMap<TicketPurchaseOrderAccount>
{
    static readonly ValueConverter<Dictionary<string, string>, string> ConfigurationSettingsConversions = new(
        v => JsonSerializer.Serialize(v, ApplicationConstants.JsonSerializerOptions),
        v => JsonSerializer.Deserialize<Dictionary<string, string>>(v, ApplicationConstants.JsonSerializerOptions));

    public override void Configure(EntityTypeBuilder<TicketPurchaseOrderAccount> builder)
    {
        builder.ToTable("TicketPurchaseOrderAccounts");

        builder.Property(x => x.AdminId).IsRequired();
        builder.Property(x => x.Count).IsRequired(true);
        builder.Property(x => x.OrderedCount).IsRequired(true).HasDefaultValue(0);
        builder.Property(x => x.TicketAccountDefinitionId).IsRequired();
        builder.Property(x => x.TicketPurchaseOrderId).IsRequired();
        builder.Property(x => x.TicketEventOrderSelections).HasConversion(ConfigurationSettingsConversions)
            .IsRequired(false).HasMaxLength(1000); 

        base.Configure(builder);
    }
}