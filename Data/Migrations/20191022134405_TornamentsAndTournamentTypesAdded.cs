using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAIF2020.Data.Migrations
{
    public partial class TornamentsAndTournamentTypesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TournamentType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tornament",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentName = table.Column<string>(nullable: true),
                    TournamentDateTime = table.Column<DateTime>(nullable: false),
                    TournamentTypeId = table.Column<int>(nullable: true),
                    GameId = table.Column<int>(nullable: true),
                    GameId1 = table.Column<int>(nullable: true),
                    GameId2 = table.Column<int>(nullable: true),
                    GameId3 = table.Column<int>(nullable: true),
                    GameId4 = table.Column<int>(nullable: true),
                    GameId5 = table.Column<int>(nullable: true),
                    GameId6 = table.Column<int>(nullable: true),
                    GameId7 = table.Column<int>(nullable: true),
                    GameId8 = table.Column<int>(nullable: true),
                    GameId9 = table.Column<int>(nullable: true),
                    GameId10 = table.Column<int>(nullable: true),
                    GameId11 = table.Column<int>(nullable: true),
                    GameId12 = table.Column<int>(nullable: true),
                    GameId13 = table.Column<int>(nullable: true),
                    GameId14 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tornament", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tornament_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tornament_Game_GameId1",
                        column: x => x.GameId1,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tornament_Game_GameId10",
                        column: x => x.GameId10,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tornament_Game_GameId11",
                        column: x => x.GameId11,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tornament_Game_GameId12",
                        column: x => x.GameId12,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tornament_Game_GameId13",
                        column: x => x.GameId13,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tornament_Game_GameId14",
                        column: x => x.GameId14,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tornament_Game_GameId2",
                        column: x => x.GameId2,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tornament_Game_GameId3",
                        column: x => x.GameId3,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tornament_Game_GameId4",
                        column: x => x.GameId4,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tornament_Game_GameId5",
                        column: x => x.GameId5,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tornament_Game_GameId6",
                        column: x => x.GameId6,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tornament_Game_GameId7",
                        column: x => x.GameId7,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tornament_Game_GameId8",
                        column: x => x.GameId8,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tornament_Game_GameId9",
                        column: x => x.GameId9,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tornament_TournamentType_TournamentTypeId",
                        column: x => x.TournamentTypeId,
                        principalTable: "TournamentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tornament_GameId",
                table: "Tornament",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Tornament_GameId1",
                table: "Tornament",
                column: "GameId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tornament_GameId10",
                table: "Tornament",
                column: "GameId10");

            migrationBuilder.CreateIndex(
                name: "IX_Tornament_GameId11",
                table: "Tornament",
                column: "GameId11");

            migrationBuilder.CreateIndex(
                name: "IX_Tornament_GameId12",
                table: "Tornament",
                column: "GameId12");

            migrationBuilder.CreateIndex(
                name: "IX_Tornament_GameId13",
                table: "Tornament",
                column: "GameId13");

            migrationBuilder.CreateIndex(
                name: "IX_Tornament_GameId14",
                table: "Tornament",
                column: "GameId14");

            migrationBuilder.CreateIndex(
                name: "IX_Tornament_GameId2",
                table: "Tornament",
                column: "GameId2");

            migrationBuilder.CreateIndex(
                name: "IX_Tornament_GameId3",
                table: "Tornament",
                column: "GameId3");

            migrationBuilder.CreateIndex(
                name: "IX_Tornament_GameId4",
                table: "Tornament",
                column: "GameId4");

            migrationBuilder.CreateIndex(
                name: "IX_Tornament_GameId5",
                table: "Tornament",
                column: "GameId5");

            migrationBuilder.CreateIndex(
                name: "IX_Tornament_GameId6",
                table: "Tornament",
                column: "GameId6");

            migrationBuilder.CreateIndex(
                name: "IX_Tornament_GameId7",
                table: "Tornament",
                column: "GameId7");

            migrationBuilder.CreateIndex(
                name: "IX_Tornament_GameId8",
                table: "Tornament",
                column: "GameId8");

            migrationBuilder.CreateIndex(
                name: "IX_Tornament_GameId9",
                table: "Tornament",
                column: "GameId9");

            migrationBuilder.CreateIndex(
                name: "IX_Tornament_TournamentTypeId",
                table: "Tornament",
                column: "TournamentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tornament");

            migrationBuilder.DropTable(
                name: "TournamentType");
        }
    }
}
