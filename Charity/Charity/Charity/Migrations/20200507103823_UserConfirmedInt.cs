using Microsoft.EntityFrameworkCore.Migrations;

namespace Charity.Migrations
{
    public partial class UserConfirmedInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Confirmed",
                table: "Users",
                nullable: false,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Confirmed",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
