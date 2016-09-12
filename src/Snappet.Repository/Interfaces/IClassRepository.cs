using Snappet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Repository.Interfaces
{
    public interface IClassRepository : IRepository
    {
        Task<List<Class>> List();
    }
}
