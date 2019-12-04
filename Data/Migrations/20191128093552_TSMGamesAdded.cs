using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAIF2020.Data.Migrations
{
    public partial class TSMGamesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TSMGameStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TSMGameStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TSMGameStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TSMGame",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameDateTime = table.Column<DateTime>(nullable: false),
                    WeekDay = table.Column<string>(nullable: true),
                    GameNumber = table.Column<int>(nullable: true),
                    Round = table.Column<int>(nullable: true),
                    HomeTeam = table.Column<string>(nullable: true),
                    AwayTeam = table.Column<string>(nullable: true),
                    Arena = table.Column<string>(nullable: true),
                    Series = table.Column<string>(nullable: true),
                    HD1 = table.Column<string>(nullable: true),
                    HD2 = table.Column<string>(nullable: true),
                    LD1 = table.Column<string>(nullable: true),
                    LD2 = table.Column<string>(nullable: true),
                    Supervisor = table.Column<string>(nullable: true),
                    DateChanged = table.Column<DateTime>(nullable: true),
                    ChangedBy = table.Column<string>(nullable: true),
                    TSMGameStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TSMGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TSMGame_TSMGameStatus_TSMGameStatusId",
                        column: x => x.TSMGameStatusId,
                        principalTable: "TSMGameStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TSMGame_TSMGameStatusId",
                table: "TSMGame",
                column: "TSMGameStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TSMGame");

            migrationBuilder.DropTable(
                name: "TSMGameStatus");
        }
    }
}
