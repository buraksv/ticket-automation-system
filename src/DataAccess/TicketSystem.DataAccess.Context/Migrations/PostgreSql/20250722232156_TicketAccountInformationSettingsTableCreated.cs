using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TicketSystem.DataAccess.Context.Migrations.PostgreSql
{
    /// <inheritdoc />
    public partial class TicketAccountInformationSettingsTableCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "idx_unique_provider_settings",
                table: "TicketProviderSettings");

            migrationBuilder.CreateTable(
                name: "TicketAccountDefinitionSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TicketAccountDefinitionId = table.Column<int>(type: "integer", nullable: false),
                    Key = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketAccountDefinitionSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketAccountDefinitionSettings_TicketAccountDefinitions_Ti~",
                        column: x => x.TicketAccountDefinitionId,
                        principalTable: "TicketAccountDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_unique_provider_settings",
                table: "TicketProviderSettings",
                columns: new[] { "Provider", "Key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_ticket_account_definition_settings_unique",
                table: "TicketAccountDefinitionSettings",
                columns: new[] { "TicketAccountDefinitionId", "Key" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketAccountDefinitionSettings");

            migrationBuilder.DropIndex(
                name: "idx_unique_provider_settings",
                table: "TicketProviderSettings");

            migrationBuilder.CreateIndex(
                name: "idx_unique_provider_settings",
                table: "TicketProviderSettings",
                columns: new[] { "Provider", "Key" });
        }
    }
}
