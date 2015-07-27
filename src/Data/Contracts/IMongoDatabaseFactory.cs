using MongoDB.Driver;

namespace SnappetChallenge.Data.Contracts
{
    public interface IMongoDatabaseFactory
    {
        IMongoDatabase Create();
    }
}