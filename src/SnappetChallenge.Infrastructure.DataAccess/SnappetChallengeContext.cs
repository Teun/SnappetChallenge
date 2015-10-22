using Microsoft.Data.Entity;
using Microsoft.Data.Sqlite;
using SnappetChallenge.Domain.Contracts;
using SnappetChallenge.Domain.Entities;
using SnappetChallenge.Infrastructure.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappetChallenge.Infrastructure.DataAccess
{
    public class SnappetChallengeContext : ISnappetChallengeContext, IDisposable
    {
        private SnappetChallengeContextImplemented context;

        public SnappetChallengeContext(string connectionString)
        {
            context = new SnappetChallengeContextImplemented(connectionString);
            context.Database.EnsureCreated();

        }
    
        public void Commit()
        {
            context.SaveChanges();
        }

        public IRepository<T> GetRepository<T>() where T : class, IEntity
        {
            // could be cached depending on your application needs
            var repository = (IRepository<T>)Activator.CreateInstance(typeof(Repository<T>), new[] {context });
            return repository;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SnappetChallengeContext() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }

    // Composition over inheritance
    // Doing this specifically from code to get EF7 working with Sqlite and code first
    internal class SnappetChallengeContextImplemented : DbContext
    {
        private readonly string connectionString;

        public SnappetChallengeContextImplemented(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Explicitly define model here (generic repo leads to lack of conventions)
            modelBuilder.Entity<Subject>();
            modelBuilder.Entity<Domain.Entities.Domain>();
            modelBuilder.Entity<LearningObjective>();
            modelBuilder.Entity<Exercise>();
            modelBuilder.Entity<SubmittedAnswer>();
            modelBuilder.Entity<User>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = new SqliteConnection(connectionString);
            optionsBuilder.UseSqlite(connection);
        }
    }
}