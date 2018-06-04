using SnappetChallenge.Core.Entities;
using System;
using System.Threading.Tasks;

namespace SnappetChallenge.Core.Repositories.Contracts
{
    public interface IWorkRepository
    {
        Works Get(DateTime initialDate, DateTime finalDate);
    }
}
