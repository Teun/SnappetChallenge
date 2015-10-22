using Microsoft.Data.Entity;
using SnappetChallenge.Domain.Contracts;
using SnappetChallenge.Domain.Entities;
using System.Linq;
using System.Collections.Generic;

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
            // EF7 does not implement find (yet) so no local caching, but for demo purposes this is good enough
            return dbSet.Single(e => e.Id == id);
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
