using Gronio.Database.EntityFramework.PostgreSql;
using Gronio.Utility.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Enums;

namespace TicketSystem.DataAccess.Context.Mappings.PostgreSql;

internal sealed class TicketPurchaseOrderDatabaseMappings : PostgreSqlRecordBaseMap<TicketPurchaseOrder>
{
    public override void Configure(EntityTypeBuilder<TicketPurchaseOrder> builder)
    {
        builder.ToTable("TicketPurchaseOrders");

        builder.Property(x => x.AdminId).IsRequired();
        builder.Property(x => x.AutomationRunTime).IsRequired();
        builder.Property(x => x.EventTime).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
        builder.Property(x => x.TeamId).IsRequired();
        builder.Property(x => x.TicketPlaceId).IsRequired();
        builder.Property(x => x.TicketEventId).HasMaxLength(128).IsRequired();
        builder.Property(x => x.TicketSystem).IsRequired(true)
            .HasComment(EnumExtensions.GetTextAllEnumKeyValues(",", TicketSystemTypeEnum.None));

        base.Configure(builder);
    }
}