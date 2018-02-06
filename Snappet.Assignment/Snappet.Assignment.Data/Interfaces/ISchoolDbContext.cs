using Microsoft.EntityFrameworkCore;
using Snappet.Assignment.Entities.DomainObjects;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Snappet.Assignment.Data.Interfaces
{
    public interface ISchoolDbContext:IDisposable
    {
        DbSet<Work> Works { get; set; }
        DbSet<Exercise> Exercises { get; set; }
        DbSet<User> Users { get; set; }

        Task<IQueryable<TEntity>> QueryAsync<TEntity>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class;
    }
}
