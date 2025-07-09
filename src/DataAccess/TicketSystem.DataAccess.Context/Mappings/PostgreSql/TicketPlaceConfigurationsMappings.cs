using System.Text.Json;
using Gronio.Database.EntityFramework.PostgreSql;
using Gronio.Utility.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketSystem.Common.Constants;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Enums;

namespace TicketSystem.DataAccess.Context.Mappings.PostgreSql;

internal sealed class TicketPlaceConfigurationsMappings : PostgreSqlRecordBaseMap<TicketPlaceConfigurations>
{
    static readonly ValueConverter<Dictionary<string, string>, string> ConfigurationSettingsConversions = new(
        v => JsonSerializer.Serialize(v, ApplicationConstants.JsonSerializerOptions),
        v => JsonSerializer.Deserialize<Dictionary<string, string>>(v, ApplicationConstants.JsonSerializerOptions));

    public override void Configure(EntityTypeBuilder<TicketPlaceConfigurations> builder)
    {
        builder.ToTable("TicketPlaceConfigurations");

        builder.Property(x => x.TicketSystemId).IsRequired().HasMaxLength(128);
        builder.Property(x => x.TicketSystem).IsRequired().HasComment(EnumExtensions.GetTextAllEnumDescriptions<TicketSystemTypeEnum>(",", TicketSystemTypeEnum.None));
        builder.Property(x => x.Definitions).HasConversion(ConfigurationSettingsConversions).IsRequired(false).HasMaxLength(1000);

        base.Configure(builder);
    }
}