using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAIF2020.Data.Migrations
{
    public partial class ArchivedGamesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArchivedGame",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(nullable: false),
                    GameNumber = table.Column<string>(nullable: true),
                    GameCetegory = table.Column<string>(nullable: true),
                    GameStatus = table.Column<string>(nullable: true),
                    GameType = table.Column<string>(nullable: true),
                    Arena = table.Column<string>(nullable: true),
                    HomeTeam = table.Column<string>(nullable: true),
                    AwayTeam = table.Column<string>(nullable: true),
                    Score = table.Column<string>(nullable: true),
                    HD1 = table.Column<string>(nullable: true),
                    HD2 = table.Column<string>(nullable: true),
                    LD1 = table.Column<string>(nullable: true),
                    LD2 = table.Column<string>(nullable: true),
                    ParticipatedTime = table.Column<decimal>(nullable: false),
                    PersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivedGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArchivedGame_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchivedGame_PersonId",
                table: "ArchivedGame",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchivedGame");
        }
    }
}
