using System.Collections.Generic;

namespace Snappet.Challenge.Domain
{
    public interface IRepository<out T>
        where T : class
    {
        IEnumerable<T> GetAll();
    }
}
