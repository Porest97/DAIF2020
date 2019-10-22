using Microsoft.EntityFrameworkCore.Migrations;

namespace DAIF2020.Data.Migrations
{
    public partial class ZoneGameReceiptsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZoneGameReceipt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiptCategoryId = table.Column<int>(nullable: true),
                    ReceiptStatusId = table.Column<int>(nullable: true),
                    ReceiptTypeId = table.Column<int>(nullable: true),
                    ZoneGameId = table.Column<int>(nullable: true),
                    UDZ1Fee = table.Column<int>(nullable: false),
                    UDZ1TravelKost = table.Column<int>(nullable: false),
                    UDZ1Alowens = table.Column<int>(nullable: false),
                    DUZ1LateGameKost = table.Column<int>(nullable: false),
                    UDZ1Other = table.Column<int>(nullable: false),
                    UDZ1TotalFee = table.Column<int>(nullable: false),
                    UDZ2Fee = table.Column<int>(nullable: false),
                    UDZ2TravelKost = table.Column<int>(nullable: false),
                    UDZ2Alowens = table.Column<int>(nullable: false),
                    UDZ2LateGameKost = table.Column<int>(nullable: false),
                    UDZ2Other = table.Column<int>(nullable: false),
                    UDZ2TotalFee = table.Column<int>(nullable: false),
                    ZoneGameTotalKost = table.Column<int>(nullable: false),
                    AmountPaidUDZ1 = table.Column<int>(nullable: false),
                    AmountPaidUDZ2 = table.Column<int>(nullable: false),
                    TotalAmountPaid = table.Column<int>(nullable: false),
                    TotalAmountToPay = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZoneGameReceipt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZoneGameReceipt_ReceiptCategory_ReceiptCategoryId",
                        column: x => x.ReceiptCategoryId,
                        principalTable: "ReceiptCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZoneGameReceipt_ReceiptStatus_ReceiptStatusId",
                        column: x => x.ReceiptStatusId,
                        principalTable: "ReceiptStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZoneGameReceipt_ReceiptType_ReceiptTypeId",
                        column: x => x.ReceiptTypeId,
                        principalTable: "ReceiptType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZoneGameReceipt_ZoneGame_ZoneGameId",
                        column: x => x.ZoneGameId,
                        principalTable: "ZoneGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZoneGameReceipt_ReceiptCategoryId",
                table: "ZoneGameReceipt",
                column: "ReceiptCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneGameReceipt_ReceiptStatusId",
                table: "ZoneGameReceipt",
                column: "ReceiptStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneGameReceipt_ReceiptTypeId",
                table: "ZoneGameReceipt",
                column: "ReceiptTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneGameReceipt_ZoneGameId",
                table: "ZoneGameReceipt",
                column: "ZoneGameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZoneGameReceipt");
        }
    }
}
