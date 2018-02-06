using Snappet.Assignment.Business.Interfaces;
using Snappet.Assignment.Data.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Snappet.Assignment.Business.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        ISchoolDbContext _context;
        internal Repository(ISchoolDbContext context)
        {
            _context = context;
        }

        public virtual async Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includes)
        {

            return (await _context.QueryAsync(predicate, includes));

        }
        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {

            return (await GetAllAsync(predicate, includes)).FirstOrDefault();

        }





    }
}
