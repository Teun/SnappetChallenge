using System.Threading.Tasks;

namespace Snappet.Test.Kernel
{
    public interface IUnitOfWork
    {
        void Insert<T>(T entity) where T : Entity;
        Task SaveAsync();
    }
}