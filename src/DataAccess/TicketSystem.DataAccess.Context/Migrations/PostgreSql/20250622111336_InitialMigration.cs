using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TicketSystem.DataAccess.Context.Migrations.PostgreSql
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Surname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    MailAddress = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Username = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemSettings",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SystemName = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TeamName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    TicketSystem = table.Column<byte>(type: "smallint", nullable: false, comment: "1 - PassoLig,2 - Biletix,3 - BuBilet,4 - BiletiniAl,5 - TicketMaster"),
                    TicketSystemConfigurations = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketPurchaseOrderSystemLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LogType = table.Column<byte>(type: "smallint", nullable: false, comment: "1 - Info,2 - Error,3 - Warning,4 - Debug"),
                    LogMessage = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketPurchaseOrderSystemLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TranslateRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LanguageOptions = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslateRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketAccountDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdminId = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Surname = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    AccountType = table.Column<byte>(type: "smallint", nullable: false, comment: "1 - System,2 - Customer"),
                    TicketSystem = table.Column<byte>(type: "smallint", nullable: false, comment: "1 - PassoLig,2 - Biletix,3 - BuBilet,4 - BiletiniAl,5 - TicketMaster"),
                    TeamId = table.Column<short>(type: "smallint", nullable: false),
                    TicketSystemLoginInformation = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    TicketSystemIsValid = table.Column<bool>(type: "boolean", nullable: false),
                    TicketSystemLastValidationControlTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketAccountDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketAccountDefinitions_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketAccountDefinitions_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketPurchaseOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdminId = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    TeamId = table.Column<short>(type: "smallint", nullable: false),
                    TicketSystem = table.Column<byte>(type: "smallint", nullable: false),
                    TicketEventId = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    EventTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AutomationRunTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketPurchaseOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketPurchaseOrders_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketPurchaseOrders_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TranslateResources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TranslateRecordId = table.Column<int>(type: "integer", nullable: false),
                    LanguageId = table.Column<byte>(type: "smallint", nullable: false),
                    Key = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Value = table.Column<string>(type: "character varying(50000)", maxLength: 50000, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslateResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranslateResources_TranslateRecords_TranslateRecordId",
                        column: x => x.TranslateRecordId,
                        principalTable: "TranslateRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketPurchaseOrderAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdminId = table.Column<short>(type: "smallint", nullable: false),
                    TicketPurchaseOrderId = table.Column<int>(type: "integer", nullable: false),
                    TicketAccountDefinitionId = table.Column<int>(type: "integer", nullable: false),
                    TicketEventOrderSelections = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Count = table.Column<byte>(type: "smallint", nullable: false),
                    OrderedCount = table.Column<byte>(type: "smallint", nullable: false, defaultValue: (byte)0),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketPurchaseOrderAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketPurchaseOrderAccounts_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketPurchaseOrderAccounts_TicketAccountDefinitions_Ticket~",
                        column: x => x.TicketAccountDefinitionId,
                        principalTable: "TicketAccountDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketPurchaseOrderAccounts_TicketPurchaseOrders_TicketPurc~",
                        column: x => x.TicketPurchaseOrderId,
                        principalTable: "TicketPurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketPurchaseCompletedOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TicketPurchaseOrderId = table.Column<int>(type: "integer", nullable: false),
                    TicketPurchaseOrderAccountId = table.Column<int>(type: "integer", nullable: false),
                    TicketOrderedInformations = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    TicketPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    TicketSalePrice = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketPurchaseCompletedOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketPurchaseCompletedOrders_TicketPurchaseOrderAccounts_T~",
                        column: x => x.TicketPurchaseOrderAccountId,
                        principalTable: "TicketPurchaseOrderAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketPurchaseCompletedOrders_TicketPurchaseOrders_TicketPu~",
                        column: x => x.TicketPurchaseOrderId,
                        principalTable: "TicketPurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_IsActive",
                table: "Admins",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_IsActive",
                table: "Teams",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_TicketAccountDefinitions_AdminId",
                table: "TicketAccountDefinitions",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketAccountDefinitions_IsActive",
                table: "TicketAccountDefinitions",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_TicketAccountDefinitions_TeamId",
                table: "TicketAccountDefinitions",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPurchaseCompletedOrders_TicketPurchaseOrderAccountId",
                table: "TicketPurchaseCompletedOrders",
                column: "TicketPurchaseOrderAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPurchaseCompletedOrders_TicketPurchaseOrderId",
                table: "TicketPurchaseCompletedOrders",
                column: "TicketPurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPurchaseOrderAccounts_AdminId",
                table: "TicketPurchaseOrderAccounts",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPurchaseOrderAccounts_IsDeleted",
                table: "TicketPurchaseOrderAccounts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPurchaseOrderAccounts_TicketAccountDefinitionId",
                table: "TicketPurchaseOrderAccounts",
                column: "TicketAccountDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPurchaseOrderAccounts_TicketPurchaseOrderId",
                table: "TicketPurchaseOrderAccounts",
                column: "TicketPurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPurchaseOrders_AdminId",
                table: "TicketPurchaseOrders",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPurchaseOrders_IsActive",
                table: "TicketPurchaseOrders",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPurchaseOrders_TeamId",
                table: "TicketPurchaseOrders",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslateResources_Key_Value",
                table: "TranslateResources",
                columns: new[] { "Key", "Value" });

            migrationBuilder.CreateIndex(
                name: "IX_TranslateResources_LanguageId_Key_Value",
                table: "TranslateResources",
                columns: new[] { "LanguageId", "Key", "Value" });

            migrationBuilder.CreateIndex(
                name: "IX_TranslateResources_TranslateRecordId",
                table: "TranslateResources",
                column: "TranslateRecordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemSettings");

            migrationBuilder.DropTable(
                name: "TicketPurchaseCompletedOrders");

            migrationBuilder.DropTable(
                name: "TicketPurchaseOrderSystemLogs");

            migrationBuilder.DropTable(
                name: "TranslateResources");

            migrationBuilder.DropTable(
                name: "TicketPurchaseOrderAccounts");

            migrationBuilder.DropTable(
                name: "TranslateRecords");

            migrationBuilder.DropTable(
                name: "TicketAccountDefinitions");

            migrationBuilder.DropTable(
                name: "TicketPurchaseOrders");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
