using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using MongoDB.Driver;

using SnappetChallenge.Data.Contracts;

namespace SnappetChallenge.Data
{
    public class MongoRepository<T> : IMongoRepository<T>
    {
        protected IMongoCollection<T> Collection;

        public MongoRepository(IMongoDatabaseFactory databaseFactory, string collectionName)
        {
            Collection = databaseFactory.Create().GetCollection<T>(collectionName);
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> query)
        {
            return await Collection.Find(query).ToListAsync();
        }

        public async Task<IEnumerable<T>> All()
        {
            return await Collection.Find(_ => true).ToListAsync();
        }
    }
}