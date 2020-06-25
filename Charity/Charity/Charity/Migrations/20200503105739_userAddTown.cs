using Microsoft.EntityFrameworkCore.Migrations;

namespace Charity.Migrations
{
    public partial class userAddTown : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "Users");
        }
    }
}
