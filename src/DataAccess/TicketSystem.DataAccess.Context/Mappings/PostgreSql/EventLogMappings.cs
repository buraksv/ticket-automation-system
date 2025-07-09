using Gronio.Database.EntityFramework.PostgreSql;
using Gronio.Utility.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Enums;

namespace TicketSystem.DataAccess.Context.Mappings.PostgreSql;

internal sealed class EventLogMappings : PostgreSqlRecordBaseMap<EventLog>
{
    public override void Configure(EntityTypeBuilder<EventLog> builder)
    {
        builder.ToTable("EventLogs");

        builder.Property(x => x.Message).HasMaxLength(1024);
        builder.Property(x => x.IpAddress).HasMaxLength(256);
        builder.Property(x => x.Type).IsRequired().HasComment(EnumExtensions.GetTextAllEnumKeyValues<EventLogTypeEnum>(",", EventLogTypeEnum.None));

        base.Configure(builder);
    }
}