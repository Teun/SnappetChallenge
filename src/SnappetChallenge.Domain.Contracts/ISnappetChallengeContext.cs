using SnappetChallenge.Domain.Entities;

namespace SnappetChallenge.Domain.Contracts
{
    public interface ISnappetChallengeContext
    {
        IRepository<T> GetRepository<T>() where T : class, IEntity;
        void Commit();
    }
}
