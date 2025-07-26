using Gronio.Database.EntityFramework.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSystem.DataAccess.Entity;

namespace TicketSystem.DataAccess.Context.Mappings.PostgreSql;

internal sealed class TicketAccountDefinitionSettingDatabaseMappings : PostgreSqlRecordBaseMap<TicketAccountDefinitionSetting>
{
    public override void Configure(EntityTypeBuilder<TicketAccountDefinitionSetting> builder)
    {
        builder.ToTable("TicketAccountDefinitionSettings");

        builder.HasIndex(x => new { x.TicketAccountDefinitionId, x.Key }, "idx_ticket_account_definition_settings_unique").IsUnique();

        builder.Property(x => x.TicketAccountDefinitionId).IsRequired();
        builder.Property(x => x.Key).IsRequired().HasMaxLength(128);
        builder.Property(x => x.Value).IsRequired(false).HasMaxLength(2048);

        base.Configure(builder);
    }
}