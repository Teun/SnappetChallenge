namespace SnappetChallenge.DAL.Repository
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using Entities;

    public class SnappetChallengeRepository<T> where T : BaseEntity
    {
            internal SnappetChallengeContext context;
            internal DbSet<T> dbSet;

            public SnappetChallengeRepository(SnappetChallengeContext context)
            {
                this.context = context;
                this.dbSet = context.Set<T>();
            }

            public virtual IQueryable<T> Get(
                Expression<Func<T, bool>> filterBy = null,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                string includeProperties = "")
            {
                IQueryable<T> query = dbSet;

                if (filterBy != null)
                {
                    query = query.Where(filterBy);
                }

                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                return orderBy != null ? orderBy(query) : query;
            }

            public virtual T GetById(object id)
            {
                return dbSet.Find(id);
            }

            public virtual void Insert(T entity)
            {
                dbSet.Add(entity);
            }

            public virtual void Delete(object id)
            {
                T entityToDelete = dbSet.Find(id);
                Delete(entityToDelete);
            }

            public virtual void Delete(T entityToDelete)
            {
                if (context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    dbSet.Attach(entityToDelete);
                }
                dbSet.Remove(entityToDelete);
            }

            public virtual void Update(T entityToUpdate)
            {
                dbSet.Attach(entityToUpdate);
                context.Entry(entityToUpdate).State = EntityState.Modified;
            }
        }
    }
