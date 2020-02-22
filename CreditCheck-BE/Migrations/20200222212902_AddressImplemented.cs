using Microsoft.EntityFrameworkCore.Migrations;

namespace CreditCheck_BE.Migrations
{
    public partial class AddressImplemented : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Addreses",
                table: "Addreses");

            migrationBuilder.RenameTable(
                name: "Addreses",
                newName: "Addresses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Addreses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addreses",
                table: "Addreses",
                column: "Id");
        }
    }
}
