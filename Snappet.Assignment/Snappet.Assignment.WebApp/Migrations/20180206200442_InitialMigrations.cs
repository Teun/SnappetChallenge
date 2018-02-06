using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Snappet.Assignment.WebApp.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "School");

            migrationBuilder.CreateTable(
                name: "Exercises",
                schema: "School",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "School",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                schema: "School",
                columns: table => new
                {
                    SubmittedAnswerId = table.Column<int>(nullable: false),
                    Correct = table.Column<bool>(type: "bit", nullable: false),
                    Difficulty = table.Column<double>(type: "float", nullable: true),
                    Domain = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    LearningObjective = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Progress = table.Column<short>(type: "smallint", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubmitDateTime = table.Column<DateTime>(type: "dateTime", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.SubmittedAnswerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercises",
                schema: "School");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "School");

            migrationBuilder.DropTable(
                name: "Works",
                schema: "School");
        }
    }
}
