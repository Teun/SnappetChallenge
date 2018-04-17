using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SnappetChallenge.Core.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportItems",
                columns: table => new
                {
                    SubmittedAnswerId = table.Column<int>(nullable: false),
                    Correct = table.Column<int>(nullable: false),
                    Difficulty = table.Column<decimal>(nullable: true),
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
                    table.PrimaryKey("PK_ReportItems", x => x.SubmittedAnswerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportItems_SubmitDateTime",
                table: "ReportItems",
                column: "SubmitDateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportItems");
        }
    }
}
