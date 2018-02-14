using Snappet.EFDesinger;
using Snappet.EFRepository.Repository;
using Snappet.EFRepository.UnitOfWork;
using Snappet.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Repository
{
    public class WorkRepository : EFRepository<work, int>, IWorkRepository
    {
        public WorkRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
        
    }
}
