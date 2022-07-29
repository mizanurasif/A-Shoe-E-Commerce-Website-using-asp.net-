using Microsoft.EntityFrameworkCore.Migrations;

namespace Cobbler.Data.Migrations
{
    public partial class EditApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User_Name",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User_Name",
                table: "AspNetUsers");
        }
    }
}
