using SnappetChallenge.Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnappetChallenge.Repository.Interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<WorkResult>> GetWorkResults();
    }
}
