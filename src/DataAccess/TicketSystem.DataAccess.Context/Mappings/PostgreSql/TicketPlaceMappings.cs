using Gronio.Database.EntityFramework.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSystem.DataAccess.Entity;

namespace TicketSystem.DataAccess.Context.Mappings.PostgreSql;

internal sealed class TicketPlaceMappings : PostgreSqlRecordBaseMap<TicketPlace>
{
    public override void Configure(EntityTypeBuilder<TicketPlace> builder)
    {
        builder.ToTable("TicketPlaces");

        builder.Property(x => x.AdminId).IsRequired();
        builder.Property(x => x.PlaceName).IsRequired().HasMaxLength(128);
        builder.Property(x => x.IsActive).IsRequired();

        base.Configure(builder);
    }
}