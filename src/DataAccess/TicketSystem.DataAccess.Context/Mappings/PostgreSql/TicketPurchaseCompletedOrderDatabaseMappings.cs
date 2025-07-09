using System.Text.Json;
using Gronio.Database.EntityFramework.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketSystem.Common.Constants;
using TicketSystem.DataAccess.Entity;

namespace TicketSystem.DataAccess.Context.Mappings.PostgreSql;

internal sealed class TicketPurchaseCompletedOrderDatabaseMappings : PostgreSqlRecordBaseMap<TicketPurchaseCompletedOrder>
{
    static readonly ValueConverter<Dictionary<string, string>, string> ConfigurationSettingsConversions = new(
        v => JsonSerializer.Serialize(v, ApplicationConstants.JsonSerializerOptions),
        v => JsonSerializer.Deserialize<Dictionary<string, string>>(v, ApplicationConstants.JsonSerializerOptions));

    public override void Configure(EntityTypeBuilder<TicketPurchaseCompletedOrder> builder)
    {
        builder.ToTable("TicketPurchaseCompletedOrders");

        builder.Property(x => x.TicketPurchaseOrderId).IsRequired();
        builder.Property(x => x.TicketPurchaseOrderAccountId).IsRequired();
        builder.Property(x => x.TicketPrice).IsRequired();
        builder.Property(x => x.TicketSalePrice).IsRequired();
        builder.Property(x => x.TicketOrderedInformations).HasConversion(ConfigurationSettingsConversions)
            .IsRequired(false).HasMaxLength(1000);

        base.Configure(builder);
    }
}