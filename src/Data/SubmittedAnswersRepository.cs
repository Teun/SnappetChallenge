using Microsoft.Framework.OptionsModel;

using SnappetChallenge.Data.Contracts;
using SnappetChallenge.Models;

namespace SnappetChallenge.Data
{
    public class SubmittedAnswersRepository : MongoRepository<SubmittedAnswer>, ISubmittedAnswersRepository
    {
        public SubmittedAnswersRepository(IMongoDatabaseFactory databaseFactory, IOptions<Settings> settings)
            : base(databaseFactory, settings.Options.SubmittedAnswersCollection)
        { }
    }
}