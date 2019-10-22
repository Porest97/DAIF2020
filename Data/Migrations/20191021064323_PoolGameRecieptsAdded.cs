using Microsoft.EntityFrameworkCore.Migrations;

namespace DAIF2020.Data.Migrations
{
    public partial class PoolGameRecieptsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PoolGameReceipt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiptCategoryId = table.Column<int>(nullable: true),
                    ReceiptStatusId = table.Column<int>(nullable: true),
                    ReceiptTypeId = table.Column<int>(nullable: true),
                    PoolGameId = table.Column<int>(nullable: true),
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
                    PoolGameTotalKost = table.Column<int>(nullable: false),
                    AmountPaidUDZ1 = table.Column<int>(nullable: false),
                    AmountPaidUDZ2 = table.Column<int>(nullable: false),
                    TotalAmountPaid = table.Column<int>(nullable: false),
                    TotalAmountToPay = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoolGameReceipt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoolGameReceipt_PoolGame_PoolGameId",
                        column: x => x.PoolGameId,
                        principalTable: "PoolGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PoolGameReceipt_ReceiptCategory_ReceiptCategoryId",
                        column: x => x.ReceiptCategoryId,
                        principalTable: "ReceiptCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PoolGameReceipt_ReceiptStatus_ReceiptStatusId",
                        column: x => x.ReceiptStatusId,
                        principalTable: "ReceiptStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PoolGameReceipt_ReceiptType_ReceiptTypeId",
                        column: x => x.ReceiptTypeId,
                        principalTable: "ReceiptType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PoolGameReceipt_PoolGameId",
                table: "PoolGameReceipt",
                column: "PoolGameId");

            migrationBuilder.CreateIndex(
                name: "IX_PoolGameReceipt_ReceiptCategoryId",
                table: "PoolGameReceipt",
                column: "ReceiptCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PoolGameReceipt_ReceiptStatusId",
                table: "PoolGameReceipt",
                column: "ReceiptStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PoolGameReceipt_ReceiptTypeId",
                table: "PoolGameReceipt",
                column: "ReceiptTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PoolGameReceipt");
        }
    }
}
