using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.EFRepository.Repository.IRepository
{
    /// <summary>
    /// Represents a generic repository interface that provides the basic CRUD operations
    /// </summary>
    /// <typeparam name="T">The type of the model class</typeparam>
    /// <typeparam name="TKey">The type of the primary key for the model class</typeparam>
    public interface IRepository<T, TKey> where T : class
    {
        IQueryable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        IQueryable<T> SqlQuery(string statment);
        T Get(TKey i);
        void Add(T entity);
        void Delete(TKey i);
        void Update(T entity);
    }
}
