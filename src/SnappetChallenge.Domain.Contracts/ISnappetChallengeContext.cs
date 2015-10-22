using SnappetChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappetChallenge.Domain.Contracts
{
    public interface ISnappetChallengeContext
    {
        IRepository<T> GetRepository<T>() where T : class, IEntity;
        void Commit();
    }
}
