using Gronio.Database.EntityFramework.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSystem.DataAccess.Entity;

namespace TicketSystem.DataAccess.Context.Mappings.PostgreSql;

internal sealed class AdminDatabaseMappings : PostgreSqlRecordBaseMap<Admin>
{
    public override void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.ToTable("Admins");

        builder.Property(x => x.MailAddress).HasMaxLength(256).IsRequired(true);
        builder.Property(x => x.Name).HasMaxLength(256).IsRequired(true);
        builder.Property(x => x.Surname).HasMaxLength(256).IsRequired(true);
        builder.Property(x => x.PasswordHash).HasMaxLength(1024).IsRequired(false);
        builder.Property(x => x.Username).HasMaxLength(128).IsRequired(true);

        base.Configure(builder);
    }
}