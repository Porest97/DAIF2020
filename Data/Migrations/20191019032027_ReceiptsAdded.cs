using Microsoft.EntityFrameworkCore.Migrations;

namespace DAIF2020.Data.Migrations
{
    public partial class ReceiptsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Receipt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiptCategoryId = table.Column<int>(nullable: true),
                    ReceiptStatusId = table.Column<int>(nullable: true),
                    ReceiptTypeId = table.Column<int>(nullable: true),
                    GameId = table.Column<int>(nullable: true),
                    HD1Fee = table.Column<int>(nullable: false),
                    HD1TravelKost = table.Column<int>(nullable: false),
                    HD1Alowens = table.Column<int>(nullable: false),
                    HD1LateGameKost = table.Column<int>(nullable: false),
                    HD1Other = table.Column<int>(nullable: false),
                    HD1TotalFee = table.Column<int>(nullable: false),
                    HD2Fee = table.Column<int>(nullable: false),
                    HD2TravelKost = table.Column<int>(nullable: false),
                    HD2Alowens = table.Column<int>(nullable: false),
                    HD2LateGameKost = table.Column<int>(nullable: false),
                    HD2Other = table.Column<int>(nullable: false),
                    HD2TotalFee = table.Column<int>(nullable: false),
                    LD1Fee = table.Column<int>(nullable: false),
                    LD1TravelKost = table.Column<int>(nullable: false),
                    LD1Alowens = table.Column<int>(nullable: false),
                    LD1LateGameKost = table.Column<int>(nullable: false),
                    LD1Other = table.Column<int>(nullable: false),
                    LD1TotalFee = table.Column<int>(nullable: false),
                    LD2Fee = table.Column<int>(nullable: false),
                    LD2TravelKost = table.Column<int>(nullable: false),
                    LD2Alowens = table.Column<int>(nullable: false),
                    LD2LateGameKost = table.Column<int>(nullable: false),
                    LD2Other = table.Column<int>(nullable: false),
                    LD2TotalFee = table.Column<int>(nullable: false),
                    GameTotalKost = table.Column<int>(nullable: false),
                    AmountPaidHD1 = table.Column<int>(nullable: false),
                    AmountPaidHD2 = table.Column<int>(nullable: false),
                    AmountPaidLD1 = table.Column<int>(nullable: false),
                    AmountPaidLD2 = table.Column<int>(nullable: false),
                    TotalAmountPaid = table.Column<int>(nullable: false),
                    TotalAmountToPay = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receipt_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receipt_ReceiptCategory_ReceiptCategoryId",
                        column: x => x.ReceiptCategoryId,
                        principalTable: "ReceiptCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receipt_ReceiptStatus_ReceiptStatusId",
                        column: x => x.ReceiptStatusId,
                        principalTable: "ReceiptStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receipt_ReceiptType_ReceiptTypeId",
                        column: x => x.ReceiptTypeId,
                        principalTable: "ReceiptType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_GameId",
                table: "Receipt",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_ReceiptCategoryId",
                table: "Receipt",
                column: "ReceiptCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_ReceiptStatusId",
                table: "Receipt",
                column: "ReceiptStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_ReceiptTypeId",
                table: "Receipt",
                column: "ReceiptTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receipt");
        }
    }
}
