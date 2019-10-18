using Microsoft.EntityFrameworkCore.Migrations;

namespace DAIF2020.Data.Migrations
{
    public partial class TeamsAndTeamRostersAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamRosterId",
                table: "Team",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TeamRoster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamRosterName = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    PersonId1 = table.Column<int>(nullable: true),
                    PersonId2 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamRoster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamRoster_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamRoster_Person_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamRoster_Person_PersonId2",
                        column: x => x.PersonId2,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Team_TeamRosterId",
                table: "Team",
                column: "TeamRosterId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamRoster_PersonId",
                table: "TeamRoster",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamRoster_PersonId1",
                table: "TeamRoster",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_TeamRoster_PersonId2",
                table: "TeamRoster",
                column: "PersonId2");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_TeamRoster_TeamRosterId",
                table: "Team",
                column: "TeamRosterId",
                principalTable: "TeamRoster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_TeamRoster_TeamRosterId",
                table: "Team");

            migrationBuilder.DropTable(
                name: "TeamRoster");

            migrationBuilder.DropIndex(
                name: "IX_Team_TeamRosterId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "TeamRosterId",
                table: "Team");
        }
    }
}
