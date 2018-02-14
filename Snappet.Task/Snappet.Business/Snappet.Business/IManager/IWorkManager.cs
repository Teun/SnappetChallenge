using Snappet.EFDesinger;
using System.Linq;

namespace Snappet.Business.IManager
{
    public interface IWorkManager
    {
        IQueryable<work> GetStudentWork();
    }
}
