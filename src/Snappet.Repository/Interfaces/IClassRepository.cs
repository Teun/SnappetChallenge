using Snappet.Model;
using Snappet.Repository.Implementation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Repository.Interfaces
{
    public interface IClassRepository : IBasicRepository<Class>
    {
        Task<List<Class>> List();

        Task<List<String>> ListSubjects();

        Task<List<String>> ListDomains();

        Task<List<String>> ListLearningObjectives();
    }
}
