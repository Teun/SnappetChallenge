using Microsoft.EntityFrameworkCore;
using Snappet.Data.Contexts;
using Snappet.Model.Context.Interfaces;
using Snappet.Repository.Implementation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snappet.Repository.Implementation.Base
{
    public abstract class BasicRepository<T> where T : class, IBasicContext
    {
        protected SnappetContext SnappetContext { get; private set; }
        private readonly DbSet<T> dbSet;

        public BasicRepository(SnappetContext snappetContext, DbSet<T> dbSet)
        {
            this.SnappetContext = snappetContext;
            this.dbSet = dbSet;
        }

        public void Add(T item)
        {
            dbSet.Add(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            dbSet.AddRange(items);
        }

        public T Find(int ID)
        {
            return dbSet.FirstOrDefault(a => a.ID == ID);
        }

        //Search() is very handy for soms very specific situations that we don't want to implement in implementations of BasicRepository. 
        //However it goes against the idea of a repository and might give too much freedom...
        //TODO: Revise this later?
        public IQueryable<T> Search()
        {
            return dbSet.AsQueryable<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }
        public T Update(T item)
        {
            dbSet.Attach(item).State = EntityState.Modified;
            return item;
        }

        public void Remove(int ID)
        {
            T answer = dbSet.FirstOrDefault(a => a.ID == ID);

            if (answer != null)
            {
                dbSet.Remove(answer);
            }
            else
            {
                throw new Exception("Invalid ID passed to Remove.");
            }
        }

        public void Save()
        {
            SnappetContext.SaveChanges();
        }

        #region IDisposable

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    SnappetContext.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
