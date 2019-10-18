using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAIF2020.Data.Migrations
{
    public partial class PoolGamesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PoolGame",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoolGameDateTime = table.Column<DateTime>(nullable: false),
                    PoolGameName = table.Column<string>(nullable: true),
                    ArenaId = table.Column<int>(nullable: true),
                    ClubId = table.Column<int>(nullable: true),
                    ZoneGameId = table.Column<int>(nullable: true),
                    ZoneGameId1 = table.Column<int>(nullable: true),
                    ZoneGameId2 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoolGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoolGame_Arena_ArenaId",
                        column: x => x.ArenaId,
                        principalTable: "Arena",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PoolGame_Club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PoolGame_ZoneGame_ZoneGameId",
                        column: x => x.ZoneGameId,
                        principalTable: "ZoneGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PoolGame_ZoneGame_ZoneGameId1",
                        column: x => x.ZoneGameId1,
                        principalTable: "ZoneGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PoolGame_ZoneGame_ZoneGameId2",
                        column: x => x.ZoneGameId2,
                        principalTable: "ZoneGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PoolGame_ArenaId",
                table: "PoolGame",
                column: "ArenaId");

            migrationBuilder.CreateIndex(
                name: "IX_PoolGame_ClubId",
                table: "PoolGame",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_PoolGame_ZoneGameId",
                table: "PoolGame",
                column: "ZoneGameId");

            migrationBuilder.CreateIndex(
                name: "IX_PoolGame_ZoneGameId1",
                table: "PoolGame",
                column: "ZoneGameId1");

            migrationBuilder.CreateIndex(
                name: "IX_PoolGame_ZoneGameId2",
                table: "PoolGame",
                column: "ZoneGameId2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PoolGame");
        }
    }
}
