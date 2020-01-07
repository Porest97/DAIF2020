using Microsoft.EntityFrameworkCore.Migrations;

namespace DAIF2020.Data.Migrations
{
    public partial class MeetingToActivityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeetingId",
                table: "Activity",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activity_MeetingId",
                table: "Activity",
                column: "MeetingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Meeting_MeetingId",
                table: "Activity",
                column: "MeetingId",
                principalTable: "Meeting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Meeting_MeetingId",
                table: "Activity");

            migrationBuilder.DropIndex(
                name: "IX_Activity_MeetingId",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "MeetingId",
                table: "Activity");
        }
    }
}
