using Snappet.Assignment.Business.Interfaces;
using Snappet.Assignment.Data.Interfaces;
using Snappet.Assignment.Entities.DomainObjects;

namespace Snappet.Assignment.Business.Repositories
{
    public class WorkRepository : Repository<Work>, IWorkRepository
    {
        public WorkRepository(ISchoolDbContext context) : base(context)
        {
        }

    }
}
