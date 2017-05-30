using Microsoft.EntityFrameworkCore;
using Snappet.Web.Persistence.Models;

namespace Snappet.Web.Persistence
{
    public class SnappetDbContext : DbContext
    {
        public DbSet<SubmittedAnswer> SubmittedAnswers { get; set; }

        public DbSet<Report> Reports { get; set; }

        public SnappetDbContext(DbContextOptions<SnappetDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubmittedAnswer>(b =>
            {
                b.HasKey(p => p.SubmittedAnswerId);
                b.Property(p => p.SubmittedAnswerId).ValueGeneratedNever();

                b.Property(p => p.Progress).IsRequired();
                b.Property(p => p.SubmitDateTime).IsRequired();
                b.Property(p => p.Correct).IsRequired();
                b.Property(p => p.UserId).IsRequired();
                b.Property(p => p.ExerciseId).IsRequired();
                b.Property(p => p.Subject).IsRequired().HasMaxLength(250);
                b.Property(p => p.Domain).IsRequired().HasMaxLength(250);
                b.Property(p => p.LearningObjective).IsRequired().HasMaxLength(500);
            });


            modelBuilder.Entity<Report>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property(p => p.DisplayName).IsRequired().HasMaxLength(100);
                b.Property(p => p.StorageProcedure).IsRequired().HasMaxLength(250);
            });

            modelBuilder.Entity<ReportConfiguration>(b =>
            {
                b.HasKey(p=> p.Id);
            });

            modelBuilder.Entity<ReportParameter>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property(p => p.Name).IsRequired().HasMaxLength(20);
                b.Property(p => p.Type).IsRequired().HasMaxLength(20);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
