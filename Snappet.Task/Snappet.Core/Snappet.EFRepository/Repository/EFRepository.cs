using Snappet.EFRepository.Repository.IRepository;
using Snappet.EFRepository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.EFRepository.Repository
{
    /// <summary>
    /// An implementation for the <code>IGenericRepository</code> interface, it supports the basic CRUD operations
    /// using Entity Framework 6
    /// </summary>
    /// <typeparam name="T">The type of the model class</typeparam>
    /// <typeparam name="TKey">The type of the primary key for the model class</typeparam>
    // ReSharper disable once InconsistentNaming
    public abstract class EFRepository<T, TKey> : IRepository<T, TKey>
        where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        //  readonly protected IUserInfo _UserInfo;

        public EFRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


        public T Get(TKey i)
        {
            return this._unitOfWork.Context.Set<T>().Find(i);
        }

        public IQueryable<T> SqlQuery(string statment)
        {
            return this._unitOfWork.Context.Set<T>().SqlQuery(statment).AsQueryable();
        }

        public IQueryable<T> GetAll()
        {
            return _unitOfWork.Context.Set<T>();
        }
        public IQueryable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _unitOfWork.Context.Set<T>().Where(predicate);
            return query;
        }

        public void Add(T entity)
        {
            _unitOfWork.Context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _unitOfWork.Context.Set<T>().Attach(entity);
        }

        public void Delete(TKey i)
        {
            _unitOfWork.Context.Set<T>().Remove(_unitOfWork.Context.Set<T>().Find(i));
        }
    }
}
