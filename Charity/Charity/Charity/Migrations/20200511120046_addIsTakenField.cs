using Microsoft.EntityFrameworkCore.Migrations;

namespace Charity.Migrations
{
    public partial class addIsTakenField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isTaken",
                table: "Adverts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isTaken",
                table: "Adverts");
        }
    }
}
