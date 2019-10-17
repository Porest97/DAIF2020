using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAIF2020.Data.Migrations
{
    public partial class GamesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameDateTime = table.Column<DateTime>(nullable: false),
                    GameNumber = table.Column<string>(nullable: true),
                    TSMNumber = table.Column<string>(nullable: true),
                    GameCategoryId = table.Column<int>(nullable: true),
                    GameStatusId = table.Column<int>(nullable: true),
                    GameTypeId = table.Column<int>(nullable: true),
                    ArenaId = table.Column<int>(nullable: true),
                    ClubId = table.Column<int>(nullable: true),
                    ClubId1 = table.Column<int>(nullable: true),
                    HomeTeamScore = table.Column<int>(nullable: true),
                    AwayTeamScore = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    PersonId1 = table.Column<int>(nullable: true),
                    PersonId2 = table.Column<int>(nullable: true),
                    PersonId3 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_Arena_ArenaId",
                        column: x => x.ArenaId,
                        principalTable: "Arena",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_Club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_Club_ClubId1",
                        column: x => x.ClubId1,
                        principalTable: "Club",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_GameCategory_GameCategoryId",
                        column: x => x.GameCategoryId,
                        principalTable: "GameCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_GameStatus_GameStatusId",
                        column: x => x.GameStatusId,
                        principalTable: "GameStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_GameType_GameTypeId",
                        column: x => x.GameTypeId,
                        principalTable: "GameType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_Person_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_Person_PersonId2",
                        column: x => x.PersonId2,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_Person_PersonId3",
                        column: x => x.PersonId3,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_ArenaId",
                table: "Game",
                column: "ArenaId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_ClubId",
                table: "Game",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_ClubId1",
                table: "Game",
                column: "ClubId1");

            migrationBuilder.CreateIndex(
                name: "IX_Game_GameCategoryId",
                table: "Game",
                column: "GameCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_GameStatusId",
                table: "Game",
                column: "GameStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_GameTypeId",
                table: "Game",
                column: "GameTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_PersonId",
                table: "Game",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_PersonId1",
                table: "Game",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_Game_PersonId2",
                table: "Game",
                column: "PersonId2");

            migrationBuilder.CreateIndex(
                name: "IX_Game_PersonId3",
                table: "Game",
                column: "PersonId3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Game");
        }
    }
}
