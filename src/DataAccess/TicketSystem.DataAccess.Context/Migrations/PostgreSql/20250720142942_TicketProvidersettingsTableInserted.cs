using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TicketSystem.DataAccess.Context.Migrations.PostgreSql
{
    /// <inheritdoc />
    public partial class TicketProvidersettingsTableInserted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicketProviderSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Provider = table.Column<byte>(type: "smallint", nullable: false, comment: "1 - PassoLig,2 - Biletix,3 - BuBilet,4 - BiletiniAl,5 - TicketMaster"),
                    Key = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketProviderSettings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "idx_unique_provider_settings",
                table: "TicketProviderSettings",
                columns: new[] { "Provider", "Key" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketProviderSettings");
        }
    }
}
