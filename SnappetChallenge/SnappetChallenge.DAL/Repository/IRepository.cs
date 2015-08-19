namespace SnappetChallenge.DAL.Repository
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    
    using Entities;

    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        T Get(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
    }
}