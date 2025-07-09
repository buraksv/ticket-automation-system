using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSystem.DataAccess.Context.Migrations.PostgreSql
{
    /// <inheritdoc />
    public partial class EventLogAdminIdColumnInserted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "AdminId",
                table: "EventLogs",
                type: "smallint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventLogs_AdminId",
                table: "EventLogs",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventLogs_Admins_AdminId",
                table: "EventLogs",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventLogs_Admins_AdminId",
                table: "EventLogs");

            migrationBuilder.DropIndex(
                name: "IX_EventLogs_AdminId",
                table: "EventLogs");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "EventLogs");
        }
    }
}
