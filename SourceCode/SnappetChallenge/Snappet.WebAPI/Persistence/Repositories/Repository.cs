using Snappet.WebAPI.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Snappet.WebAPI.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        private DbSet<TEntity> entities;

        public Repository(DbContext context)
        {
            Context = context;
            entities = Context.Set<TEntity>();
        }

        public TEntity Get(int id)
        {
            return entities.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return entities.ToList();
        }

    }
}