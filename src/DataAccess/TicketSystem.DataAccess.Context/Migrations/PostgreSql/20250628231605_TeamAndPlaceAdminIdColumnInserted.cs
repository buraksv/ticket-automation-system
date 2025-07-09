using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSystem.DataAccess.Context.Migrations.PostgreSql
{
    /// <inheritdoc />
    public partial class TeamAndPlaceAdminIdColumnInserted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "AdminId",
                table: "TicketPlaces",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "AdminId",
                table: "Teams",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "TicketPlaces");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Teams");
        }
    }
}
