using Gronio.Database.EntityFramework.PostgreSql;
using Gronio.Utility.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Enums;

namespace TicketSystem.DataAccess.Context.Mappings.PostgreSql;

internal sealed class TicketProviderSettingMappings : PostgreSqlRecordBaseMap<TicketProviderSetting>
{
    public override void Configure(EntityTypeBuilder<TicketProviderSetting> builder)
    {
        builder.ToTable("TicketProviderSettings");

        builder.HasIndex(x => new { x.Provider, x.Key }, "idx_unique_provider_settings");

        builder.Property(x => x.Provider).IsRequired().HasComment(EnumExtensions.GetTextAllEnumKeyValues(",", TicketSystemTypeEnum.None));
        builder.Property(x => x.Key).IsRequired().HasMaxLength(128);
        builder.Property(x => x.Value).IsRequired(false).HasMaxLength(2048);

        base.Configure(builder);
    }
}