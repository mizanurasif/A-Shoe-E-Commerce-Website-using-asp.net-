using Microsoft.EntityFrameworkCore.Migrations;

namespace Cobbler.Data.Migrations
{
    public partial class EditApplicationUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User_Name",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "User_Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
