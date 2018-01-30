using System.Data.Entity;
using SnappetChallenge.Core.Entities;
using SnappetChallenge.Core.Interfaces;

namespace SnappetChallenge.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context, ICommands<Assessment> assessmentCommands, IQueries<Assessment> assessmentQueries)
        {
            _context = context;
            AssessmentQueries = assessmentQueries;
            AssessmentCommands = assessmentCommands;
        }

        public IQueries<Assessment> AssessmentQueries { get; }
        public ICommands<Assessment> AssessmentCommands { get; }

        public bool AutoDetectChange
        {
            set { _context.Configuration.AutoDetectChangesEnabled = value; }
        }

        public bool ValidateOnSaveEnabled
        {
            set { _context.Configuration.ValidateOnSaveEnabled = value; }
        }
       
        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void BulkCommit()
        {
           _context.BulkSaveChanges();
        }
    }
}
