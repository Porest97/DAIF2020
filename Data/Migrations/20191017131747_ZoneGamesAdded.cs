using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAIF2020.Data.Migrations
{
    public partial class ZoneGamesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZoneGame",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameCategoryId = table.Column<int>(nullable: true),
                    GameStatusId = table.Column<int>(nullable: true),
                    GameTypeId = table.Column<int>(nullable: true),
                    ZoneId = table.Column<int>(nullable: true),
                    TSMNumberZone1 = table.Column<string>(nullable: true),
                    ClubId = table.Column<int>(nullable: true),
                    ClubId1 = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    ZoneId1 = table.Column<int>(nullable: true),
                    TSMNumberZone2 = table.Column<string>(nullable: true),
                    ClubId2 = table.Column<int>(nullable: true),
                    ClubId3 = table.Column<int>(nullable: true),
                    PersonId1 = table.Column<int>(nullable: true),
                    PersonId2 = table.Column<int>(nullable: true),
                    ArenaId = table.Column<int>(nullable: true),
                    ZoneGameDateTime = table.Column<DateTime>(nullable: false),
                    ZoneGameName = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZoneGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZoneGame_Arena_ArenaId",
                        column: x => x.ArenaId,
                        principalTable: "Arena",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZoneGame_Club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZoneGame_Club_ClubId1",
                        column: x => x.ClubId1,
                        principalTable: "Club",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZoneGame_Club_ClubId2",
                        column: x => x.ClubId2,
                        principalTable: "Club",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZoneGame_Club_ClubId3",
                        column: x => x.ClubId3,
                        principalTable: "Club",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZoneGame_GameCategory_GameCategoryId",
                        column: x => x.GameCategoryId,
                        principalTable: "GameCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZoneGame_GameStatus_GameStatusId",
                        column: x => x.GameStatusId,
                        principalTable: "GameStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZoneGame_GameType_GameTypeId",
                        column: x => x.GameTypeId,
                        principalTable: "GameType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZoneGame_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZoneGame_Person_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZoneGame_Person_PersonId2",
                        column: x => x.PersonId2,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZoneGame_Zone_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZoneGame_Zone_ZoneId1",
                        column: x => x.ZoneId1,
                        principalTable: "Zone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZoneGame_ArenaId",
                table: "ZoneGame",
                column: "ArenaId");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneGame_ClubId",
                table: "ZoneGame",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneGame_ClubId1",
                table: "ZoneGame",
                column: "ClubId1");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneGame_ClubId2",
                table: "ZoneGame",
                column: "ClubId2");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneGame_ClubId3",
                table: "ZoneGame",
                column: "ClubId3");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneGame_GameCategoryId",
                table: "ZoneGame",
                column: "GameCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneGame_GameStatusId",
                table: "ZoneGame",
                column: "GameStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneGame_GameTypeId",
                table: "ZoneGame",
                column: "GameTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneGame_PersonId",
                table: "ZoneGame",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneGame_PersonId1",
                table: "ZoneGame",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneGame_PersonId2",
                table: "ZoneGame",
                column: "PersonId2");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneGame_ZoneId",
                table: "ZoneGame",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneGame_ZoneId1",
                table: "ZoneGame",
                column: "ZoneId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZoneGame");
        }
    }
}
