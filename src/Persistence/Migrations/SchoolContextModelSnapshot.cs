using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Persistence;

namespace Persistence.Migrations
{
	[DbContext(typeof(SchoolContext))]
	partial class SchoolContextModelSnapshot : ModelSnapshot
	{
		protected override void BuildModel(ModelBuilder modelBuilder)
		{
			modelBuilder
				.HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
				.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

			modelBuilder.Entity("Domain.Exercise", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd();

					b.Property<double?>("Difficulty");

					b.Property<int?>("LearningObjectiveId")
						.IsRequired();

					b.HasKey("Id");

					b.HasIndex("LearningObjectiveId");

					b.ToTable("Exercises");
				});

			modelBuilder.Entity("Domain.KnowledgeDomain", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd();

					b.Property<string>("Name");

					b.HasKey("Id");

					b.HasIndex("Name");

					b.ToTable("KnowledgeDomains");
				});

			modelBuilder.Entity("Domain.LearningObjective", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd();

					b.Property<int?>("DomainId")
						.IsRequired();

					b.Property<string>("Name");

					b.Property<int?>("SubjectId")
						.IsRequired();

					b.HasKey("Id");

					b.HasIndex("DomainId");

					b.HasIndex("Name");

					b.HasIndex("SubjectId");

					b.ToTable("LearningObjectives");
				});

			modelBuilder.Entity("Domain.Subject", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd();

					b.Property<string>("Name");

					b.HasKey("Id");

					b.HasIndex("Name");

					b.ToTable("Subjects");
				});

			modelBuilder.Entity("Domain.SubmittedAnswer", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd();

					b.Property<bool>("Correct");

					b.Property<int?>("ExerciseId")
						.IsRequired();

					b.Property<int>("Progress");

					b.Property<DateTimeOffset>("SubmittedAt");

					b.Property<int?>("UserId")
						.IsRequired();

					b.HasKey("Id");

					b.HasIndex("ExerciseId");

					b.HasIndex("UserId");

					b.ToTable("SubmittedAnswers");
				});

			modelBuilder.Entity("Domain.User", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd();

					b.Property<string>("Name");

					b.HasKey("Id");

					b.HasIndex("Name");

					b.ToTable("Users");
				});

			modelBuilder.Entity("Domain.Exercise", b =>
				{
					b.HasOne("Domain.LearningObjective", "LearningObjective")
						.WithMany()
						.HasForeignKey("LearningObjectiveId")
						.OnDelete(DeleteBehavior.Cascade);
				});

			modelBuilder.Entity("Domain.LearningObjective", b =>
				{
					b.HasOne("Domain.KnowledgeDomain", "Domain")
						.WithMany()
						.HasForeignKey("DomainId")
						.OnDelete(DeleteBehavior.Cascade);

					b.HasOne("Domain.Subject", "Subject")
						.WithMany()
						.HasForeignKey("SubjectId")
						.OnDelete(DeleteBehavior.Cascade);
				});

			modelBuilder.Entity("Domain.SubmittedAnswer", b =>
				{
					b.HasOne("Domain.Exercise", "Exercise")
						.WithMany()
						.HasForeignKey("ExerciseId")
						.OnDelete(DeleteBehavior.Cascade);

					b.HasOne("Domain.User", "User")
						.WithMany()
						.HasForeignKey("UserId")
						.OnDelete(DeleteBehavior.Cascade);
				});
		}
	}
}
