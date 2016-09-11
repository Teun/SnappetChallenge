using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Snappet.Data.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    SubmittedAnswerId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Correct = table.Column<bool>(nullable: false),
                    Difficulty = table.Column<double>(nullable: false),
                    Domain = table.Column<string>(nullable: true),
                    ExerciseId = table.Column<int>(nullable: false),
                    LearningObjective = table.Column<string>(nullable: true),
                    Progress = table.Column<int>(nullable: false),
                    Subject = table.Column<string>(nullable: true),
                    SubmitDateTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.SubmittedAnswerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");
        }
    }
}
