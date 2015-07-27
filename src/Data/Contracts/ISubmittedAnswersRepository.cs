using SnappetChallenge.Models;

namespace SnappetChallenge.Data.Contracts
{
    public interface ISubmittedAnswersRepository : IMongoRepository<SubmittedAnswer>
    { }
}