using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public class ReportItem
    {
        public int SubmittedAnswerId { get; set; }
        public DateTime SubmitDateTime { get; set; }
        public int Correct { get; set; }
        public int Progress { get; set; }
        public int UserId { get; set; }
        public int ExerciseId { get; set; }

        [JsonConverter(typeof(DifficultyConverter))]
        public decimal? Difficulty { get; set; }
        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }
    }

    public class ClassReportContext : DbContext
    {
        public ClassReportContext(DbContextOptions<ClassReportContext> options)
            : base(options)
        { }

        public DbSet<ReportItem> ReportItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReportItem>()
                .HasKey(c => c.SubmittedAnswerId);

            modelBuilder.Entity<ReportItem>()
                .Property(b => b.SubmittedAnswerId)
                .ValueGeneratedNever();

            modelBuilder.Entity<ReportItem>()
                .HasIndex(c => c.SubmitDateTime);
        }
    }
    
}