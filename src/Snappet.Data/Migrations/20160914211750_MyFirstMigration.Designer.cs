using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Snappet.Data.Contexts;

namespace Snappet.Data.Migrations
{
    [DbContext(typeof(SnappetContext))]
    [Migration("20160914211750_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("Snappet.Model.Answer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClassId");

                    b.Property<bool>("Correct");

                    b.Property<double>("Difficulty");

                    b.Property<int>("DomainID");

                    b.Property<int>("ExerciseId");

                    b.Property<int>("LearningObjectiveID");

                    b.Property<int>("Progress");

                    b.Property<int>("SubjectID");

                    b.Property<DateTime>("SubmitDateTime");

                    b.Property<int>("UserId");

                    b.HasKey("ID");

                    b.HasIndex("ClassId");

                    b.HasIndex("DomainID");

                    b.HasIndex("LearningObjectiveID");

                    b.HasIndex("SubjectID");

                    b.HasIndex("UserId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Snappet.Model.Class", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Snappet.Model.Domain", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Domains");
                });

            modelBuilder.Entity("Snappet.Model.LearningObjective", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("LearningObjectives");
                });

            modelBuilder.Entity("Snappet.Model.Subject", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Snappet.Model.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Snappet.Model.Answer", b =>
                {
                    b.HasOne("Snappet.Model.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Snappet.Model.Domain", "Domain")
                        .WithMany()
                        .HasForeignKey("DomainID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Snappet.Model.LearningObjective", "LearningObjective")
                        .WithMany()
                        .HasForeignKey("LearningObjectiveID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Snappet.Model.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Snappet.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
