using Microsoft.EntityFrameworkCore;
using Snappet.Reporting.Application.Domain.Model;

namespace Snappet.Reporting.Storage.Sql
{
    public class ReportingDbContext : DbContext
    {
        public DbSet<Answer> Answers { get; set; }

        public ReportingDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                .HasKey(c => new { c.UserId, c.ExerciseId, c.SubmittedAnswerId });
        }
    }
}
