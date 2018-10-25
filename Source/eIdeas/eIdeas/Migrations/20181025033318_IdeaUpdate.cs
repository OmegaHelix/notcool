using Microsoft.EntityFrameworkCore.Migrations;

namespace eIdeas.Migrations
{
    public partial class IdeaUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Team",
                table: "Idea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Idea",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Team",
                table: "Idea");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Idea");
        }
    }
}
