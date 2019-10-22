using Microsoft.EntityFrameworkCore.Migrations;

namespace DAIF2020.Data.Migrations
{
    public partial class DUZ1LateGameKostToUDZ1LateGameKost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DUZ1LateGameKost",
                table: "ZoneGameReceipt");

            migrationBuilder.AddColumn<int>(
                name: "UDZ1LateGameKost",
                table: "ZoneGameReceipt",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UDZ1LateGameKost",
                table: "ZoneGameReceipt");

            migrationBuilder.AddColumn<int>(
                name: "DUZ1LateGameKost",
                table: "ZoneGameReceipt",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
