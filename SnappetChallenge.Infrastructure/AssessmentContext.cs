using System.Data.Entity;
using SnappetChallenge.Core.Entities;

namespace SnappetChallenge.Infrastructure
{
    public class AssessmentContext : DbContext
    {
        public AssessmentContext()
            : base("AssessmentContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<AssessmentContext>());
        }

        public virtual DbSet<Assessment> Assessments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AssessmentEntityConfiguration());
        }
    }
}
