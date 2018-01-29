using MongoDB.Driver;
using SnappetTest.Data.Abstract;
using SnappetTest.Data.Attributes;
using Microsoft.Extensions.Options;



namespace SnappetTest.Data.Repositories
{
   public class SnappetFactory : ISnappetFactory
    {
        private readonly MongoAttributes _AttributesMongo;

        public SnappetFactory(IOptions<MongoAttributes> AttributesMongo)
        {
            _AttributesMongo = AttributesMongo.Value;
        }

        public IMongoDatabase CreateInstance()
        {
            var mongoclient = new MongoClient(_AttributesMongo.Connection);
            var database = mongoclient.GetDatabase(_AttributesMongo.Database);
            return database;
        }
      
    }
}
