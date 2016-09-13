using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snappet.Repository.Implementation.Base
{
    public interface IBasicRepository<T>
    {
        void Add(T item);

        void AddRange(IEnumerable<T> items);

        T Find(int ID);

        T Update(T item);

        IEnumerable<T> GetAll();

        void Remove(int ID);

        void Save();
    }
}
