using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SnappetChallenge.Data.Contracts
{
    public interface IMongoRepository<T>
    {
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> query);
        Task<IEnumerable<T>> All();
    }
}
