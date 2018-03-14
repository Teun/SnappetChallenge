//-----------------------------------------------------------------------
// <copyright file="Service.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Core;

    /// <summary>
    /// This class implement <see cref="IService{TEntity, TKey}"/>
    /// </summary>
    /// <typeparam name="TEntity">A generic Entity</typeparam>
    /// <typeparam name="TKey">The type of the key</typeparam>
    public class Service<TEntity, TKey> : IService<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        /// <summary>
        /// The generic repository <see cref="IRepository{TEntity, TKey}"/>
        /// </summary>
        private readonly IRepository<TEntity, TKey> repository;

        /// <summary>
        /// Is disposed
        /// </summary>
        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="Service{TEntity, TKey}" /> class
        /// </summary>
        /// <param name="unitOfWork">The implementation of Unit Of Work pattern <see cref="IUnitOfWork" /></param>
        public Service(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
            this.repository = this.UnitOfWork.Repository<TEntity, TKey>();
        }

        /// <summary>
        /// Gets or Sets the Unit Of Work pattern <see cref="IUnitOfWork" />
        /// </summary>
        public IUnitOfWork UnitOfWork { get; private set; }

        /// <summary>
        /// Gets the Repository pattern <see cref="IRepository{TEntity, TKey}" />
        /// </summary>
        public IRepository<TEntity, TKey> Repository => this.repository;        

        /// <summary>
        /// <see cref="IService{TEntity, TKey}.Entries"/>
        /// </summary>
        public IQueryable<TEntity> Entries => this.repository.Entries;

        /// <summary>
        /// <see cref="IService{TEntity, TKey}.GetAllAsync"/>
        /// </summary>
        /// <param name="disabled">Parameter disabled <see cref="IService{TEntity, TKey}.GetAllAsync(bool?,bool?)"/></param>
        /// <param name="trash">Parameter trash <see cref="IService{TEntity, TKey}.GetAllAsync(bool?,bool?)"/></param>
        /// <returns>Return <see cref="IService{TEntity, TKey}.GetAllAsync"/></returns>
        public virtual Task<List<TEntity>> GetAllAsync(bool? disabled = null, bool? trash = null)
        {
            return this.repository.GetAllAsync(disabled, trash);
        }

        /// <summary>
        /// <see cref="IService{TEntity, TKey}.GetAllQueryableAsync"/>
        /// </summary>
        /// <returns>Return <see cref="IService{TEntity, TKey}.GetAllQueryableAsync"/></returns>
        public virtual Task<IQueryable<TEntity>> GetAllQueryableAsync()
        {
            return this.repository.GetAllQueryableAsync();
        }

        /// <summary>
        /// <see cref="IService{TEntity, TKey}.GetAllByCriteriaAsync"/>
        /// </summary>
        /// <param name="predicate">Parameter <see cref="IService{TEntity, TKey}.GetAllByCriteriaAsync(Expression{Func{TEntity, bool}})"/></param>
        /// <returns>Return <see cref="IService{TEntity, TKey}.GetAllByCriteriaAsync"/></returns>
        public virtual Task<List<TEntity>> GetAllByCriteriaAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return this.repository.GetAllByCriteriaAsync(predicate);
        }

        /// <summary>
        /// <see cref="IService{TEntity, TKey}.GetAllQueryableByCriteriaAsync"/>
        /// </summary>
        /// <param name="predicate">Parameter <see cref="IService{TEntity, TKey}.GetAllQueryableByCriteriaAsync(Expression{Func{TEntity, bool}})"/></param>
        /// <returns>Return <see cref="IService{TEntity, TKey}.GetAllQueryableByCriteriaAsync"/></returns>
        public virtual Task<IQueryable<TEntity>> GetAllQueryableByCriteriaAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return this.repository.GetAllQueryableByCriteriaAsync(predicate);
        }

        /// <summary>
        /// <see cref="IService{TEntity, TKey}.GetByCriteriaAsync(Expression{Func{TEntity, bool}})"/>
        /// </summary>
        /// <param name="predicate">Parameter <see cref="IService{TEntity, TKey}.GetByCriteriaAsync(Expression{Func{TEntity, bool}})"/></param>
        /// <returns>Return <see cref="IService{TEntity, TKey}.GetByCriteriaAsync(Expression{Func{TEntity, bool}})"/></returns>
        public virtual Task<TEntity> GetByCriteriaAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return this.repository.GetByCriteriaAsync(predicate);
        }

        /// <summary>
        /// <see cref="IRepository{TEntity, TKey}.Find(TKey)"/>
        /// </summary>
        /// <param name="id">Parameter <see cref="IRepository{TEntity, TKey}.Find(TKey)"/></param>
        /// <returns>Return <see cref="IRepository{TEntity, TKey}.Find(TKey)"/></returns>
        public virtual TEntity Find(TKey id)
        {
            return this.repository.Find(id);
        }

        /// <inheritdoc/>
        public TEntity Reload(TEntity entity)
        {
            this.repository.Reload(entity);
            return entity;
        }

        /// <summary>
        /// <see cref="IService{TEntity, TKey}.Add(TEntity)"/>
        /// </summary>
        /// <param name="entity">Parameter <see cref="IService{TEntity, TKey}.Add(TEntity)"/></param>
        /// <returns>Return <see cref="IService{TEntity, TKey}.Add(TEntity)"/></returns>
        public TEntity Add(TEntity entity)
        {
            this.repository.Add(entity);
            this.UnitOfWork.Commit();

            return entity;
        }

        /// <summary>
        /// <see cref="IService{TEntity, TKey}.AddAsync(TEntity)"/>
        /// </summary>
        /// <param name="entity">Parameter <see cref="IService{TEntity, TKey}.AddAsync(TEntity)"/></param>
        /// <returns>Return <see cref="IService{TEntity, TKey}.AddAsync(TEntity)"/></returns>
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            this.repository.Add(entity);
            await this.UnitOfWork.CommitAsync();

            return entity;
        }

        /// <summary>
        /// <see cref="IService{TEntity, TKey}.Update(TEntity)"/>
        /// </summary>
        /// <param name="entity">parameter <see cref="IService{TEntity, TKey}.Update(TEntity)"/></param>
        /// <returns>Return <see cref="IService{TEntity, TKey}.Update(TEntity)"/></returns>
        public TEntity Update(TEntity entity)
        {
            this.repository.Update(entity);
            this.UnitOfWork.Commit();

            return entity;
        }

        /// <summary>
        /// <see cref="IService{TEntity, TKey}.UpdateAsync(TEntity)"/>
        /// </summary>
        /// <param name="entity">Parameter <see cref="IService{TEntity, TKey}.UpdateAsync(TEntity)"/></param>
        /// <returns>Return <see cref="IService{TEntity, TKey}.UpdateAsync(TEntity)"/></returns>
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            this.repository.Update(entity);
            await this.UnitOfWork.CommitAsync();

            return entity;
        }

        /// <summary>
        /// <see cref="IService{TEntity, TKey}.Delete(TEntity)"/>
        /// </summary>
        /// <param name="entity">Parameter <see cref="IService{TEntity, TKey}.Delete(TEntity)"/></param>
        /// <returns>Return <see cref="IService{TEntity, TKey}.Delete(TEntity)"/></returns>
        public TEntity Delete(TEntity entity)
        {
            this.repository.Delete(entity);
            this.UnitOfWork.Commit();
            return entity;
        }

        /// <summary>
        /// <see cref="IService{TEntity, TKey}.DeleteAsync(TEntity)"/>
        /// </summary>
        /// <param name="entity">Parameter <see cref="IService{TEntity, TKey}.DeleteAsync(TEntity)"/></param>
        /// <returns>Return <see cref="IService{TEntity, TKey}.DeleteAsync(TEntity)"/></returns>
        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            this.repository.Delete(entity);
            await this.UnitOfWork.CommitAsync();

            return entity;
        }

        /// <summary>
        ///  <see cref="IService{TEntity, TKey}.Dispose(bool)"/>
        /// </summary>
        /// <param name="disposing">Parameter <see cref="IService{TEntity, TKey}.Dispose(bool)"/></param>
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                this.UnitOfWork.Dispose();
            }

            this.disposed = true;
        }

        /// <summary>
        /// Call the GC
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
