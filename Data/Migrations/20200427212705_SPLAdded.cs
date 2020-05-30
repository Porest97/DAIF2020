using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAIF2020.Data.Migrations
{
    public partial class SPLAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SportName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SportsLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(nullable: true),
                    SportId = table.Column<int>(nullable: true),
                    DateTimeStart = table.Column<DateTime>(nullable: true),
                    DateTimeEnd = table.Column<DateTime>(nullable: true),
                    TimeSpent = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportsLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SportsLog_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SportsLog_Sport_SportId",
                        column: x => x.SportId,
                        principalTable: "Sport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SportsLog_PersonId",
                table: "SportsLog",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SportsLog_SportId",
                table: "SportsLog",
                column: "SportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SportsLog");

            migrationBuilder.DropTable(
                name: "Sport");
        }
    }
}
