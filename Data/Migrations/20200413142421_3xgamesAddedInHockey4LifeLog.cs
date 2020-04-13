using Microsoft.EntityFrameworkCore.Migrations;

namespace DAIF2020.Data.Migrations
{
    public partial class _3xgamesAddedInHockey4LifeLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Hockey4LifeLog",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameId1",
                table: "Hockey4LifeLog",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameId2",
                table: "Hockey4LifeLog",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hockey4LifeLog_GameId",
                table: "Hockey4LifeLog",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Hockey4LifeLog_GameId1",
                table: "Hockey4LifeLog",
                column: "GameId1");

            migrationBuilder.CreateIndex(
                name: "IX_Hockey4LifeLog_GameId2",
                table: "Hockey4LifeLog",
                column: "GameId2");

            migrationBuilder.AddForeignKey(
                name: "FK_Hockey4LifeLog_Game_GameId",
                table: "Hockey4LifeLog",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hockey4LifeLog_Game_GameId1",
                table: "Hockey4LifeLog",
                column: "GameId1",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hockey4LifeLog_Game_GameId2",
                table: "Hockey4LifeLog",
                column: "GameId2",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hockey4LifeLog_Game_GameId",
                table: "Hockey4LifeLog");

            migrationBuilder.DropForeignKey(
                name: "FK_Hockey4LifeLog_Game_GameId1",
                table: "Hockey4LifeLog");

            migrationBuilder.DropForeignKey(
                name: "FK_Hockey4LifeLog_Game_GameId2",
                table: "Hockey4LifeLog");

            migrationBuilder.DropIndex(
                name: "IX_Hockey4LifeLog_GameId",
                table: "Hockey4LifeLog");

            migrationBuilder.DropIndex(
                name: "IX_Hockey4LifeLog_GameId1",
                table: "Hockey4LifeLog");

            migrationBuilder.DropIndex(
                name: "IX_Hockey4LifeLog_GameId2",
                table: "Hockey4LifeLog");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Hockey4LifeLog");

            migrationBuilder.DropColumn(
                name: "GameId1",
                table: "Hockey4LifeLog");

            migrationBuilder.DropColumn(
                name: "GameId2",
                table: "Hockey4LifeLog");
        }
    }
}
