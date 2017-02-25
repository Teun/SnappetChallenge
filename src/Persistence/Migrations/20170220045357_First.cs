using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Persistence.Migrations
{
	public partial class First : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "KnowledgeDomains",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					Name = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_KnowledgeDomains", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Subjects",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					Name = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Subjects", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Users",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					Name = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Users", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "LearningObjectives",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					DomainId = table.Column<int>(nullable: false),
					Name = table.Column<string>(nullable: true),
					SubjectId = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_LearningObjectives", x => x.Id);
					table.ForeignKey(
						name: "FK_LearningObjectives_KnowledgeDomains_DomainId",
						column: x => x.DomainId,
						principalTable: "KnowledgeDomains",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_LearningObjectives_Subjects_SubjectId",
						column: x => x.SubjectId,
						principalTable: "Subjects",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Exercises",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					Difficulty = table.Column<double>(nullable: true),
					LearningObjectiveId = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Exercises", x => x.Id);
					table.ForeignKey(
						name: "FK_Exercises_LearningObjectives_LearningObjectiveId",
						column: x => x.LearningObjectiveId,
						principalTable: "LearningObjectives",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "SubmittedAnswers",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					Correct = table.Column<bool>(nullable: false),
					ExerciseId = table.Column<int>(nullable: false),
					Progress = table.Column<int>(nullable: false),
					SubmittedAt = table.Column<DateTimeOffset>(nullable: false),
					UserId = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_SubmittedAnswers", x => x.Id);
					table.ForeignKey(
						name: "FK_SubmittedAnswers_Exercises_ExerciseId",
						column: x => x.ExerciseId,
						principalTable: "Exercises",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_SubmittedAnswers_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Exercises_LearningObjectiveId",
				table: "Exercises",
				column: "LearningObjectiveId");

			migrationBuilder.CreateIndex(
				name: "IX_KnowledgeDomains_Name",
				table: "KnowledgeDomains",
				column: "Name");

			migrationBuilder.CreateIndex(
				name: "IX_LearningObjectives_DomainId",
				table: "LearningObjectives",
				column: "DomainId");

			migrationBuilder.CreateIndex(
				name: "IX_LearningObjectives_Name",
				table: "LearningObjectives",
				column: "Name");

			migrationBuilder.CreateIndex(
				name: "IX_LearningObjectives_SubjectId",
				table: "LearningObjectives",
				column: "SubjectId");

			migrationBuilder.CreateIndex(
				name: "IX_Subjects_Name",
				table: "Subjects",
				column: "Name");

			migrationBuilder.CreateIndex(
				name: "IX_SubmittedAnswers_ExerciseId",
				table: "SubmittedAnswers",
				column: "ExerciseId");

			migrationBuilder.CreateIndex(
				name: "IX_SubmittedAnswers_UserId",
				table: "SubmittedAnswers",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_Users_Name",
				table: "Users",
				column: "Name");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "SubmittedAnswers");

			migrationBuilder.DropTable(
				name: "Exercises");

			migrationBuilder.DropTable(
				name: "Users");

			migrationBuilder.DropTable(
				name: "LearningObjectives");

			migrationBuilder.DropTable(
				name: "KnowledgeDomains");

			migrationBuilder.DropTable(
				name: "Subjects");
		}
	}
}
