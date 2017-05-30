using Microsoft.EntityFrameworkCore.Migrations;

namespace Snappet.Web.Persistence.Migrations
{
    public partial class AddSubmittedAnswerProgress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Progress",
                table: "SubmittedAnswers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Progress",
                table: "SubmittedAnswers");
        }
    }
}
