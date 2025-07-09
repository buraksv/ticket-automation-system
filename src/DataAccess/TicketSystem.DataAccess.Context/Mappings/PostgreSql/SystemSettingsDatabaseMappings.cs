using Gronio.Database.EntityFramework.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSystem.DataAccess.Entity;

namespace TicketSystem.DataAccess.Context.Mappings.PostgreSql;

internal sealed class SystemSettingsDatabaseMappings : PostgreSqlRecordBaseMap<SystemSettings>
{
    public override void Configure(EntityTypeBuilder<SystemSettings> builder)
    {
        builder.ToTable("SystemSettings");

        builder.Property(x => x.SystemName).HasMaxLength(64).IsRequired(true);

        base.Configure(builder);
    }
}