using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Snappet.Data.Contexts;

namespace Snappet.Data.Migrations
{
    [DbContext(typeof(AnswerContext))]
    [Migration("20160911181136_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("Snappet.Model.Answer", b =>
                {
                    b.Property<int>("SubmittedAnswerId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Correct");

                    b.Property<double>("Difficulty");

                    b.Property<string>("Domain");

                    b.Property<int>("ExerciseId");

                    b.Property<string>("LearningObjective");

                    b.Property<int>("Progress");

                    b.Property<string>("Subject");

                    b.Property<DateTime>("SubmitDateTime");

                    b.Property<int>("UserId");

                    b.HasKey("SubmittedAnswerId");

                    b.ToTable("Answers");
                });
        }
    }
}
