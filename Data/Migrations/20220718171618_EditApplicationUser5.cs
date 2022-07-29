using Microsoft.EntityFrameworkCore.Migrations;

namespace Cobbler.Data.Migrations
{
    public partial class EditApplicationUser5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserrNamee",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserrNamee",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
