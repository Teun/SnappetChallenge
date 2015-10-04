using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Snappet.DataAccess
{
        public class BaseRepository<T> where T : class
        {
            private readonly SnappetContext _dbContext;

            public BaseRepository(SnappetContext dbContext)
            {
                _dbContext = dbContext;
            }

            public T Get(Func<T, bool> predicate)
            {
                return GetAll(predicate).FirstOrDefault();
            }

            public IEnumerable<T> GetAll(Func<T, bool> predicate = null)
            {
                IEnumerable<T> result = _dbContext.Set<T>().AsEnumerable();
                return (predicate == null) ? result : result.Where<T>(predicate);
            }

            public void Add(T entity)
            {
                _dbContext.Entry(entity).State = EntityState.Added;
            }
        public void Add(List<T> entities)
        {
            foreach (var entity in entities)
            {
                _dbContext.Entry(entity).State = EntityState.Added;
            }
        }

       
            public void Delete(T entity)
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }

        public void DeleteAll(string tableName)
        {
            var sqlQuery = string.Format("delete  from {0}", tableName);
            _dbContext.Database.ExecuteSqlCommand(sqlQuery);
            _dbContext.SaveChanges();
        }


        public void Save()
            {
                _dbContext.SaveChanges();
            }

            public void Dispose()
            {
                if (_dbContext != null)
                    _dbContext.Dispose();
            }
        }
    }
