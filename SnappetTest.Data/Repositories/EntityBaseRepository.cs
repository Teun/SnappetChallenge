using MongoDB.Driver;
using SnappetTest.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SnappetTest.Data.Repositories
{
   public class EntityBaseRepository<T>: IEntityBaseRepository<T>
    {
        protected IMongoCollection<T> _Collections;

        public EntityBaseRepository(ISnappetFactory snappentDB, string Collections)
        {
            _Collections = snappentDB.CreateInstance().GetCollection<T>(Collections);
        }
        public IEnumerable<T> GetAll()
        {
          return  _Collections.Find(_ => true).ToList();
        }

        public IEnumerable<T> GetSingle(Expression<Func<T, bool>> predicate)
        {
            return _Collections.Find(predicate).ToList();
        }
    }
}
