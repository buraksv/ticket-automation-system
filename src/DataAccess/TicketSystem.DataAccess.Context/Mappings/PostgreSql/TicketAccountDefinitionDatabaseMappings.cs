using Gronio.Database.EntityFramework.PostgreSql;
using Gronio.Utility.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;
using TicketSystem.Common.Constants;
using TicketSystem.DataAccess.Entity;
using TicketSystem.Enums;

namespace TicketSystem.DataAccess.Context.Mappings.PostgreSql;

internal sealed class TicketAccountDefinitionDatabaseMappings : PostgreSqlRecordBaseMap<TicketAccountDefinition>
{
    static readonly ValueConverter<Dictionary<string, string>, string> ConfigurationSettingsConversions = new(
        v => JsonSerializer.Serialize(v, ApplicationConstants.JsonSerializerOptions),
        v => JsonSerializer.Deserialize<Dictionary<string, string>>(v, ApplicationConstants.JsonSerializerOptions));

    public override void Configure(EntityTypeBuilder<TicketAccountDefinition> builder)
    {
        builder.ToTable("TicketAccountDefinitions");

        builder.Property(x => x.AdminId).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(128).IsRequired();
        builder.Property(x => x.Surname).HasMaxLength(128).IsRequired();
        builder.Property(x => x.TeamId).IsRequired();
        builder.Property(x => x.TicketSystemIsValid).IsRequired();
        builder.Property(x => x.TicketSystemLastValidationControlTime).IsRequired(false);
        builder.Property(x => x.TicketSystemLoginInformation).HasConversion(ConfigurationSettingsConversions)
            .IsRequired(false).HasMaxLength(1000);
        builder.Property(x => x.TicketSystem).IsRequired(true).HasComment(EnumExtensions.GetTextAllEnumKeyValues(",", TicketSystemTypeEnum.None));
        builder.Property(x => x.AccountType).IsRequired(true).HasComment(EnumExtensions.GetTextAllEnumKeyValues(",", TicketAccountTypeEnum.None)); 

        base.Configure(builder);
    }
}