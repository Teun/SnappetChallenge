using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Snappet.Assignment.WebApp.Migrations
{
    public partial class InitialMigrations1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Works_ExerciseId",
                schema: "School",
                table: "Works",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_UserId",
                schema: "School",
                table: "Works",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Exercises_ExerciseId",
                schema: "School",
                table: "Works",
                column: "ExerciseId",
                principalSchema: "School",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Users_UserId",
                schema: "School",
                table: "Works",
                column: "UserId",
                principalSchema: "School",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_Exercises_ExerciseId",
                schema: "School",
                table: "Works");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Users_UserId",
                schema: "School",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_ExerciseId",
                schema: "School",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_UserId",
                schema: "School",
                table: "Works");
        }
    }
}
