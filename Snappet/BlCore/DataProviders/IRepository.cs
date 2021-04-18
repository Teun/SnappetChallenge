using System.Linq;

namespace BlCore.DataProviders
{
    public interface IRepository<out T>
    {
        IQueryable<T> Get();
    }
}
