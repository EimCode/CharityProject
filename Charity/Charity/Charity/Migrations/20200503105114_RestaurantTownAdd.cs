using Microsoft.EntityFrameworkCore.Migrations;

namespace Charity.Migrations
{
    public partial class RestaurantTownAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "Restaurants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Town",
                table: "Restaurants");
        }
    }
}
