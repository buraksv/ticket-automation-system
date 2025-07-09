using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TicketSystem.DataAccess.Context.Migrations.PostgreSql
{
    /// <inheritdoc />
    public partial class NewTablesInserted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketSystemConfigurations",
                table: "Teams");

            migrationBuilder.AlterColumn<byte>(
                name: "TicketSystem",
                table: "TicketPurchaseOrders",
                type: "smallint",
                nullable: false,
                comment: "1 - PassoLig,2 - Biletix,3 - BuBilet,4 - BiletiniAl,5 - TicketMaster",
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AddColumn<short>(
                name: "TicketPlaceId",
                table: "TicketPurchaseOrders",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<string>(
                name: "TicketSystemId",
                table: "Teams",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "EventLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<byte>(type: "smallint", nullable: false, comment: "1 - Information,2 - Warning,3 - Danger,4 - Success"),
                    Message = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketPlaces",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlaceName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketPlaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketPlaceConfigurations",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TicketPlaceId = table.Column<short>(type: "smallint", nullable: false),
                    TicketSystem = table.Column<byte>(type: "smallint", nullable: false, comment: "PassoLig,Biletix,BuBilet,BiletiniAl,TicketMaster"),
                    TicketSystemId = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Definitions = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketPlaceConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketPlaceConfigurations_TicketPlaces_TicketPlaceId",
                        column: x => x.TicketPlaceId,
                        principalTable: "TicketPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketPurchaseOrders_TicketPlaceId",
                table: "TicketPurchaseOrders",
                column: "TicketPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPlaceConfigurations_TicketPlaceId",
                table: "TicketPlaceConfigurations",
                column: "TicketPlaceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketPlaces_IsActive",
                table: "TicketPlaces",
                column: "IsActive");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketPurchaseOrders_TicketPlaces_TicketPlaceId",
                table: "TicketPurchaseOrders",
                column: "TicketPlaceId",
                principalTable: "TicketPlaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketPurchaseOrders_TicketPlaces_TicketPlaceId",
                table: "TicketPurchaseOrders");

            migrationBuilder.DropTable(
                name: "EventLogs");

            migrationBuilder.DropTable(
                name: "TicketPlaceConfigurations");

            migrationBuilder.DropTable(
                name: "TicketPlaces");

            migrationBuilder.DropIndex(
                name: "IX_TicketPurchaseOrders_TicketPlaceId",
                table: "TicketPurchaseOrders");

            migrationBuilder.DropColumn(
                name: "TicketPlaceId",
                table: "TicketPurchaseOrders");

            migrationBuilder.DropColumn(
                name: "TicketSystemId",
                table: "Teams");

            migrationBuilder.AlterColumn<byte>(
                name: "TicketSystem",
                table: "TicketPurchaseOrders",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint",
                oldComment: "1 - PassoLig,2 - Biletix,3 - BuBilet,4 - BiletiniAl,5 - TicketMaster");

            migrationBuilder.AddColumn<string>(
                name: "TicketSystemConfigurations",
                table: "Teams",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true);
        }
    }
}
