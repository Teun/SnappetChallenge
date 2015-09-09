using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StudyReport.Entities;

namespace StudyReport.DataAccess
{
    public class StudyReportContext : DbContext
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Domain> Domains { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<LearningObjective> LearningObjectives { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkModel> WorkModel { get; set; }

        public StudyReportContext()
        {
            Database.SetInitializer<StudyReportContext>(new StudyReportInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<DateTime>()
            .Configure(c => c.HasColumnType("datetime2"));
        }
    }
}
