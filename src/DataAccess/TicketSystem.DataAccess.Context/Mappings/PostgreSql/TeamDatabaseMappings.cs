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

internal sealed class TeamDatabaseMappings : PostgreSqlRecordBaseMap<Team>
{
    static readonly ValueConverter<Dictionary<string,string>, string> ConfigurationSettingsConversions = new(
        v => JsonSerializer.Serialize(v, ApplicationConstants.JsonSerializerOptions),
        v => JsonSerializer.Deserialize<Dictionary<string, string>>(v, ApplicationConstants.JsonSerializerOptions));

    public override void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.ToTable("Teams");

        builder.Property(x => x.AdminId).IsRequired();
        builder.Property(x => x.TeamName).HasMaxLength(128).IsRequired(true); 
        builder.Property(x => x.TicketSystem).IsRequired(true)
            .HasComment(EnumExtensions.GetTextAllEnumKeyValues(",", TicketSystemTypeEnum.None));

        base.Configure(builder);
    }
}