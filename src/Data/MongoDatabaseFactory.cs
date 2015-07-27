using Microsoft.Framework.OptionsModel;

using MongoDB.Driver;

using SnappetChallenge.Data.Contracts;

namespace SnappetChallenge.Data
{
    /// <summary>
    /// Factory to create an IMongoDatabase instance.
    /// </summary>
    /// <remarks>
    /// The database need to connect with certain settings and needs to pick up the settings from somewhere.
    /// This seemed cleaner than preparing the instance in the composition root (Startup.cs).
    /// I might be wrong.
    /// TODO: an open question is if the connection is properly cleaned up.
    /// </remarks>
    public class MongoDatabaseFactory : IMongoDatabaseFactory
    {
        private readonly Settings _settings;

        public MongoDatabaseFactory(IOptions<Settings> settings)
        {
            _settings = settings.Options;
        }

        public IMongoDatabase Create()
        {
            var client = new MongoClient(_settings.Connection);
            var database = client.GetDatabase(_settings.Database);

            return database;
        }
    }
}