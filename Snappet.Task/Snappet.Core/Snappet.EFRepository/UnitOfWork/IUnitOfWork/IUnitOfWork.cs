using Snappet.EFDesinger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.EFRepository.UnitOfWork
{
    public interface IUnitOfWork
    {
        snappetdbEntities Context { get; }
    }
}
