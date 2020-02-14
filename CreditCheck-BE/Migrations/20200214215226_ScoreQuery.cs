using Microsoft.EntityFrameworkCore.Migrations;

namespace CreditCheck_BE.Migrations
{
    public partial class ScoreQuery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScoreQueryId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ScoreQueries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<int>(nullable: false),
                    StreetName = table.Column<string>(nullable: true),
                    StreetType = table.Column<string>(nullable: false),
                    AptNumber = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: false),
                    Zip = table.Column<string>(nullable: true),
                    SocialNumber = table.Column<int>(nullable: false),
                    IsCurrentLocation = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreQueries", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_ScoreQueries_ScoreQueryId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "ScoreQueries");

            migrationBuilder.DropIndex(
                name: "IX_Users_ScoreQueryId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ScoreQueryId",
                table: "Users");
        }
    }
}
