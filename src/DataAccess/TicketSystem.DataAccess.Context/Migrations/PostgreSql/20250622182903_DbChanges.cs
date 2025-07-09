using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSystem.DataAccess.Context.Migrations.PostgreSql
{
    /// <inheritdoc />
    public partial class DbChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "OrderedCount",
                table: "TicketPurchaseOrderAccounts",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(byte),
                oldType: "smallint",
                oldDefaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "OrderedCount",
                table: "TicketPurchaseOrderAccounts",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldDefaultValue: (short)0);
        }
    }
}
