using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eIdeas.Migrations
{
    public partial class Table_Adjusments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User",
                table: "Like",
                newName: "UserID");

            migrationBuilder.AddColumn<DateTime>(
                name: "UploadDate",
                table: "Comment",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UploadDate",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Like",
                newName: "User");
        }
    }
}
