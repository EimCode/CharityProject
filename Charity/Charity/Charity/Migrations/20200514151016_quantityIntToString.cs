using Microsoft.EntityFrameworkCore.Migrations;

namespace Charity.Migrations
{
    public partial class quantityIntToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Quantity",
                table: "Food",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Food",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
