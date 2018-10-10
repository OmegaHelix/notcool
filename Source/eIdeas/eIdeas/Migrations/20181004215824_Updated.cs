using Microsoft.EntityFrameworkCore.Migrations;

namespace eIdeas.Migrations
{
    public partial class Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdeaNo",
                table: "Idea");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdeaNo",
                table: "Idea",
                nullable: false,
                defaultValue: 0);
        }
    }
}
