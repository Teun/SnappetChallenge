using SnappetChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappetChallenge.Domain.Contracts
{
    public interface IRepository<T> where T : class, IEntity
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        T Get(long id);
        IQueryable<T> GetAll();
    }
}
