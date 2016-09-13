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
        private readonly DbContext context;
        private readonly DbSet<T> dbSet;

        public BasicRepository(DbContext context, DbSet<T> dbSet)
        {
            this.context = context;
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
            context.SaveChanges();
        }

        #region IDisposable

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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
