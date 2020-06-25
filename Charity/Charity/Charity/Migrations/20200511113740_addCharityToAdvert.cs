using Microsoft.EntityFrameworkCore.Migrations;

namespace Charity.Migrations
{
    public partial class addCharityToAdvert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CharityGroupId",
                table: "Adverts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_CharityGroupId",
                table: "Adverts",
                column: "CharityGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_Users_CharityGroupId",
                table: "Adverts",
                column: "CharityGroupId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_Users_CharityGroupId",
                table: "Adverts");

            migrationBuilder.DropIndex(
                name: "IX_Adverts_CharityGroupId",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "CharityGroupId",
                table: "Adverts");
        }
    }
}
