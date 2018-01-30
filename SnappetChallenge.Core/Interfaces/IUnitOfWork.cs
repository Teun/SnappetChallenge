using System;
using SnappetChallenge.Core.Entities;

namespace SnappetChallenge.Core.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IQueries<Assessment> AssessmentQueries { get; }
        ICommands<Assessment> AssessmentCommands { get; }
        bool AutoDetectChange { set; }
        bool ValidateOnSaveEnabled { set; }
        int Commit();
        void BulkCommit();
      
    }
}