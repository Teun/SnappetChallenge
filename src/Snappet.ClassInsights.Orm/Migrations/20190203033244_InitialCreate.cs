using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Snappet.ClassInsights.Orm.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubmittedAnswers",
                columns: table => new
                {
                    SubmittedAnswerId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SubmitDateTime = table.Column<DateTime>(nullable: false),
                    Correct = table.Column<int>(nullable: false),
                    Progress = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ExerciseId = table.Column<long>(nullable: false),
                    Difficulty = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Domain = table.Column<string>(nullable: true),
                    LearningObjective = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmittedAnswers", x => x.SubmittedAnswerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubmittedAnswers");
        }
    }
}
