using Microsoft.EntityFrameworkCore.Migrations;

namespace Charity.Migrations
{
    public partial class addAdvertToFood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Adverts_Advertid",
                table: "Food");

            migrationBuilder.RenameColumn(
                name: "Advertid",
                table: "Food",
                newName: "AdvertId");

            migrationBuilder.RenameIndex(
                name: "IX_Food_Advertid",
                table: "Food",
                newName: "IX_Food_AdvertId");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Adverts_AdvertId",
                table: "Food",
                column: "AdvertId",
                principalTable: "Adverts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Adverts_AdvertId",
                table: "Food");

            migrationBuilder.RenameColumn(
                name: "AdvertId",
                table: "Food",
                newName: "Advertid");

            migrationBuilder.RenameIndex(
                name: "IX_Food_AdvertId",
                table: "Food",
                newName: "IX_Food_Advertid");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Adverts_Advertid",
                table: "Food",
                column: "Advertid",
                principalTable: "Adverts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
