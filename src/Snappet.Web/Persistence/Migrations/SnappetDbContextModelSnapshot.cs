using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Snappet.Web.Persistence.Migrations
{
    [DbContext(typeof(SnappetDbContext))]
    partial class SnappetDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("Snappet.Web.Persistence.Models.ReportConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ReportId");

                    b.HasKey("Id");

                    b.HasIndex("ReportId")
                        .IsUnique();

                    b.ToTable("ReportConfiguration");
                });

            modelBuilder.Entity("Snappet.Web.Persistence.Models.ReportParameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("ReportConfigurationId");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("ReportConfigurationId");

                    b.ToTable("ReportParameter");
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

            modelBuilder.Entity("Snappet.Web.Persistence.Models.ReportConfiguration", b =>
                {
                    b.HasOne("Snappet.Web.Persistence.Models.Report")
                        .WithOne("ReportConfiguration")
                        .HasForeignKey("Snappet.Web.Persistence.Models.ReportConfiguration", "ReportId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Snappet.Web.Persistence.Models.ReportParameter", b =>
                {
                    b.HasOne("Snappet.Web.Persistence.Models.ReportConfiguration")
                        .WithMany("Parameters")
                        .HasForeignKey("ReportConfigurationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
