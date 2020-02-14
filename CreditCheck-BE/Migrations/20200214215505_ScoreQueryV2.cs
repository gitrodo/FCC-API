using Microsoft.EntityFrameworkCore.Migrations;

namespace CreditCheck_BE.Migrations
{
    public partial class ScoreQueryV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_ScoreQueries_ScoreQueryId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ScoreQueryId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ScoreQueryId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ScoreQueries",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScoreQueries_UserId",
                table: "ScoreQueries",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreQueries_Users_UserId",
                table: "ScoreQueries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScoreQueries_Users_UserId",
                table: "ScoreQueries");

            migrationBuilder.DropIndex(
                name: "IX_ScoreQueries_UserId",
                table: "ScoreQueries");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ScoreQueries");

            migrationBuilder.AddColumn<int>(
                name: "ScoreQueryId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ScoreQueryId",
                table: "Users",
                column: "ScoreQueryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ScoreQueries_ScoreQueryId",
                table: "Users",
                column: "ScoreQueryId",
                principalTable: "ScoreQueries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
