using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Snappet.Web.Persistence;

namespace Snappet.Web.Persistence.Migrations
{
    [DbContext(typeof(SnappetDbContext))]
    [Migration("20170525133021_AddSubmittedAnswerProgress")]
    partial class AddSubmittedAnswerProgress
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Snappet.Web.Persistence.Models.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("StorageProcedure")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Snappet.Web.Persistence.Models.SubmittedAnswer", b =>
                {
                    b.Property<long>("SubmittedAnswerId");

                    b.Property<int>("Correct");

                    b.Property<decimal?>("Difficulty");

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<long>("ExerciseId");

                    b.Property<string>("LearningObjective")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<int>("Progress");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<DateTime>("SubmitDateTime");

                    b.Property<long>("UserId");

                    b.HasKey("SubmittedAnswerId");

                    b.ToTable("SubmittedAnswers");
                });
        }
    }
}
