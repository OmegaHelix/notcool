using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eIdeas.Migrations.eIdeasUsers
{
    public partial class picturebyres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureURL",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "PictureURL",
                table: "AspNetUsers",
                nullable: true);
        }
    }
}
