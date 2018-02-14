using Snappet.EFDesinger;
using Snappet.EFRepository.Repository.IRepository;
using System.Linq;

namespace Snappet.Repository.IRepository
{
    public interface IWorkRepository : IRepository<work, int>
    {
    }
}
