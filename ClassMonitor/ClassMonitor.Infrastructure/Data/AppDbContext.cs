using ClassMonitor.Core.DomainAggregate;
using ClassMonitor.Core.LearningObjectiveAggregate;
using ClassMonitor.Core.SubjectAggregate;
using ClassMonitor.Core.UserAggregate;
using ClassMonitor.Core.WorkAggregate;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ClassMonitor.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Work> Work => Set<Work>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Subject> Subjects => Set<Subject>();
        public DbSet<Domain> Domains => Set<Domain>();
        public DbSet<LearningObjective> LearningObjectives => Set<LearningObjective>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
