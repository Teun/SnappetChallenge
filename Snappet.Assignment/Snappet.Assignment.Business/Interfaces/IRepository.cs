using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Snappet.Assignment.Business.Interfaces
{
    public interface IRepository<TEntity>
    {

        Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null,
            params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includes);


    }
}
