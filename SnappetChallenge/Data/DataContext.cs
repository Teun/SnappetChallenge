using Microsoft.EntityFrameworkCore;
using SnappetChallenge.Models;
using SnappetChallenge.AggregateModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnappetChallenge.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DailyWorkModel>()
            .HasKey(o => new { o.Subject, o.Domain, o.LearningObjective });

            modelBuilder.Entity<DayCompareToLastWeekModel>()
            .HasKey(o => new { o.Subject, o.Domain, o.LearningObjective });

            modelBuilder.Entity<DayCompareToAllModel>()
            .HasKey(o => new { o.Subject, o.Domain, o.LearningObjective });

            modelBuilder.Entity<DailyWorkModel>().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<DayCompareToLastWeekModel>().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<DayCompareToAllModel>().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<SummaryDataModel>().Metadata.SetIsTableExcludedFromMigrations(true);
        }

        public DbSet<WorkDataModel>? WorkDataModel { get; set; }

        [NotMapped]
        public DbSet<DailyWorkModel>? DailyWorkModel { get; set; }

        [NotMapped]
        public DbSet<DayCompareToLastWeekModel>? DayCompareToLastWeekModel { get; set; }

        [NotMapped]
        public DbSet<DayCompareToAllModel>? DayCompareToAllModel { get; set; }

        [NotMapped]
        public DbSet<SummaryDataModel>? SummaryDataModel { get; set; }

    }
}
