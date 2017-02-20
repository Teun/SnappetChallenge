using System;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Snappet.Test.Kernel;
using Snappet.Test.TopStudents.Core.Interfaces;
using Snappet.Test.TopStudents.Core.Model;

namespace Snappet.Test.TopStudents.Data
{
    public class TopStudentsDbContext : DbContext, ITopStudentsUnitOfWork
    {
        static TopStudentsDbContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<TopStudentsDbContext>());
        }

        public TopStudentsDbContext()
            : base(GetConnectionString())
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public TopStudentsDbContext(DbConnection dbConnection, DbTransaction dbTransaction)
            : base(dbConnection, false)
        {
            Database.UseTransaction(dbTransaction);
            Configuration.LazyLoadingEnabled = false;
        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[$"Snappet.Endpoint.TopStudents-{Environment.MachineName}"].ConnectionString;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Add model maps from this assembly
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }


        public IDbSet<TopStudentsRecord> TopStudentsRecordsDbSet { get; set; }
        public IQueryable<TopStudentsRecord> TopStudentsRecords => TopStudentsRecordsDbSet;

        public IDbSet<DaySummary> DaySummariesDbSet { get; set; }
        public IQueryable<DaySummary> DaySummaries => DaySummariesDbSet;



        public void Insert<T>(T entity) where T : Entity
        {
            Set<T>().Add(entity);
        }

        public Task SaveAsync()
        {
            return SaveChangesAsync();
        }

    }
}
