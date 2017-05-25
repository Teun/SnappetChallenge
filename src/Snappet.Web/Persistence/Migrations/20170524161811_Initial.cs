using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Snappet.Web.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubmittedAnswers",
                columns: table => new
                {
                    SubmittedAnswerId = table.Column<long>(nullable: false),
                    Correct = table.Column<int>(nullable: false),
                    Difficulty = table.Column<decimal>(nullable: true),
                    Domain = table.Column<string>(maxLength: 250, nullable: false),
                    ExerciseId = table.Column<long>(nullable: false),
                    LearningObjective = table.Column<string>(maxLength: 500, nullable: false),
                    Subject = table.Column<string>(maxLength: 250, nullable: false),
                    SubmitDateTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
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
