﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Charity.Migrations
{
    public partial class userTokenDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Users",
                nullable: true);
        }
    }
}
