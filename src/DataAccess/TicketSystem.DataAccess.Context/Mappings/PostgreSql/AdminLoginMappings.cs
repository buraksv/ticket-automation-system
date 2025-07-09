using Gronio.Database.EntityFramework.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSystem.DataAccess.Entity;

namespace TicketSystem.DataAccess.Context.Mappings.PostgreSql;

public sealed class AdminLoginMappings : PostgreSqlRecordBaseMap<AdminLogin>
{
    public override void Configure(EntityTypeBuilder<AdminLogin> builder)
    {
        builder.ToTable("AdminLogins");

        builder.Property(x => x.IsSuccess).IsRequired();
        builder.Property(x => x.InputPassword).IsRequired(false).HasMaxLength(128);
        builder.Property(x => x.InputUsername).IsRequired(false).HasMaxLength(128);

        base.Configure(builder);
    }
}