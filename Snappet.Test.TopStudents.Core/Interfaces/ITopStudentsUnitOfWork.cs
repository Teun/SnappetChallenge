using System.Linq;
using Snappet.Test.Kernel;
using Snappet.Test.TopStudents.Core.Model;

namespace Snappet.Test.TopStudents.Core.Interfaces
{
    public interface ITopStudentsUnitOfWork : IUnitOfWork
    {
        IQueryable<TopStudentsRecord> TopStudentsRecords { get; }
        IQueryable<DaySummary> DaySummaries { get; }

    }
}