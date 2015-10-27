using SnappetChallenge.Domain.Contracts;
using SnappetChallenge.Domain.Entities;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace SnappetChallenge.Infrastructure.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbSet<T> dbSet;

        public Repository(DbContext context)
        {
            dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
        }

        public T Get(long id)
        {
            return dbSet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
