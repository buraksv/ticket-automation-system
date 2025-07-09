using Gronio.Database.EntityFramework.PostgreSql;
using Gronio.Utility.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Enums;

namespace TicketSystem.DataAccess.Context.Mappings.PostgreSql;

internal sealed class TicketPurchaseOrderSystemLogDatabaseMappings : PostgreSqlRecordBaseMap<TicketPurchaseOrderSystemLog>
{
    public override void Configure(EntityTypeBuilder<TicketPurchaseOrderSystemLog> builder)
    {
        builder.ToTable("TicketPurchaseOrderSystemLogs");

        builder.Property(x => x.LogMessage).HasMaxLength(2048);
        builder.Property(x => x.LogType).IsRequired()
            .HasComment(EnumExtensions.GetTextAllEnumKeyValues(",", SystemLogTypeEnum.None));

        base.Configure(builder);
    }
}