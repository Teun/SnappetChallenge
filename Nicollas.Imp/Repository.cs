//-----------------------------------------------------------------------
// <copyright file="Repository.cs" company="Pangom Soft">
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
    /// This class implement <see cref="IRepository{TEntity, TKey}"/>
    /// </summary>
    /// <typeparam name="TEntity">A generic Entity</typeparam>
    /// <typeparam name="TKey">The type of the key</typeparam>
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        /// <summary>
        /// The DataBase Context
        /// </summary>
        private readonly IDbContext context;

        /// <summary>
        /// Is disposed
        /// </summary>
        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity, TKey}" /> class
        /// </summary>
        /// <param name="context">The implementation of Database Context <see cref="IDbContext" /></param>
        public Repository(IDbContext context)
        {
            this.context = context;
        }

        /// </inerhit>
        public IQueryable<TEntity> Entries => this.context.ToQueryable<TEntity, TKey>();

        /// </inerhit>
        public Task LoadCollection<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> propertyExpression) 
            where TProperty : class
        {
            return this.context.LoadCollectionAsync(entity,propertyExpression);
        }

        /// </inerhit>
        public Task LoadCollection(TEntity entity, string propertyName)
        {
            return this.context.LoadCollectionAsync(entity, propertyName);
        }

        /// </inerhit>
        public Task LoadReference<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> propertyExpression)
            where TProperty : class
        {
            return this.context.LoadReferenceAsync(entity, propertyExpression);
        }

        /// </inerhit>
        public Task LoadReference(TEntity entity, string propertyName)
        {
            return this.context.LoadReferenceAsync(entity, propertyName);
        }

        /// <summary>
        /// <see cref="IRepository{TEntity,TKey}.GetAllAsync"/>
        /// </summary>
        /// <param name="disabled">Parameter disabled <see cref="IService{TEntity, TKey}.GetAllAsync(bool?,bool?)"/></param>
        /// <param name="trash">Parameter trash <see cref="IService{TEntity, TKey}.GetAllAsync(bool?,bool?)"/></param>
        /// <returns>Return <see cref="IRepository{TEntity, TKey}.GetAllAsync"/></returns>
        public Task<List<TEntity>> GetAllAsync(bool? disabled, bool? trash, bool asNoTracking = true)
        {
            return this.context.ToListAsync<TEntity, TKey>(disabled, trash, asNoTracking);
        }

        /// <summary>
        /// <see cref="IRepository{TEntity,TKey}.GetAllQueryableAsync"/>
        /// </summary>
        /// <returns>Return <see cref="IRepository{TEntity, TKey}.GetAllQueryableAsync"/></returns>
        public Task<IQueryable<TEntity>> GetAllQueryableAsync(bool asNoTracking = true)
        {
            return this.context.ToQueryableAsync<TEntity, TKey>(asNoTracking);
        }

        /// <summary>
        /// <see cref="IRepository{TEntity,TKey}.GetAllByCriteriaAsync"/>
        /// </summary>
        /// <param name="predicate">A criteria</param>
        /// <returns>Return <see cref="IRepository{TEntity, TKey}.GetAllByCriteriaAsync"/></returns>
        public Task<List<TEntity>> GetAllByCriteriaAsync(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = true)
        {
            return this.context.ToListByCriteriaAsync<TEntity, TKey>(predicate, asNoTracking);
        }

        /// <summary>
        /// <see cref="IRepository{TEntity,TKey}.GetAllQueryableByCriteriaAsync"/>
        /// </summary>
        /// <param name="predicate">A criteria</param>
        /// <returns>Return <see cref="IRepository{TEntity, TKey}.GetAllQueryableByCriteriaAsync"/></returns>
        public Task<IQueryable<TEntity>> GetAllQueryableByCriteriaAsync(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = true)
        {
            return this.context.ToQueryableByCriteriaAsync<TEntity, TKey>(predicate, asNoTracking);
        }

        /// <summary>
        /// <see cref="IRepository{TEntity, TKey}.GetByCriteriaAsync(Expression{Func{TEntity, bool}})"/>
        /// </summary>
        /// <param name="predicate">Parameter <see cref="IRepository{TEntity, TKey}.GetByCriteriaAsync(Expression{Func{TEntity, bool}})"/></param>
        /// <returns>Return <see cref="IRepository{TEntity, TKey}.GetByCriteriaAsync(Expression{Func{TEntity, bool}})"/></returns>
        public Task<TEntity> GetByCriteriaAsync(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = true)
        {
            return this.context.FirstOrDefaultAsync<TEntity, TKey>(predicate, asNoTracking);
        }

        /// <summary>
        /// <see cref="IRepository{TEntity, TKey}.Find(TKey)"/>
        /// </summary>
        /// <param name="id">Parameter <see cref="IRepository{TEntity, TKey}.Find(TKey)"/></param>
        /// <returns>Return <see cref="IRepository{TEntity, TKey}.Find(TKey)"/></returns>
        public TEntity Find(TKey id)
        {
            return this.context.Find<TEntity, TKey>(id);
        }

        /// <summary>
        /// <see cref="IRepository{TEntity, TKey}.Find(TKey)"/>
        /// </summary>
        /// <param name="id">Parameter <see cref="IRepository{TEntity, TKey}.Find(TKey)"/></param>
        /// <returns>Return <see cref="IRepository{TEntity, TKey}.Find(TKey)"/></returns>
        public TEntity FindByCriteria(Expression<Func<TEntity, bool>> predicate)
        {
            return this.context.FindByCriteria<TEntity, TKey>(predicate);
        }

        /// <inheritdoc/>
        public void Reload(TEntity entity)
        {
            this.context.Reload<TEntity, TKey>(entity);
        }

        /// <summary>
        /// <see cref="IRepository{TEntity, TKey}.Add(TEntity)"/>
        /// </summary>
        /// <param name="entity">Parameter <see cref="IRepository{TEntity, TKey}.Add(TEntity)"/></param>
        public void Add(TEntity entity)
        {
            this.context.SetAsAdded<TEntity, TKey>(entity);
        }

        /// <summary>
        /// <see cref="IRepository{TEntity, TKey}.Update(TEntity)"/>
        /// </summary>
        /// <param name="entity">Parameter <see cref="IRepository{TEntity, TKey}.Update(TEntity)"/></param>
        public void Update(TEntity entity)
        {
            this.context.SetAsModified<TEntity, TKey>(entity);
        }

        /// <summary>
        /// <see cref="IRepository{TEntity, TKey}.Delete(TEntity)"/>
        /// </summary>
        /// <param name="entity">Parameter <see cref="IRepository{TEntity, TKey}.Delete(TEntity)"/></param>
        public void Delete(TEntity entity)
        {
            this.context.SetAsDeleted<TEntity, TKey>(entity);
        }

        /// <summary>
        /// <see cref="IRepository{TEntity, TKey}.Dispose(bool)"/>
        /// </summary>
        /// <param name="disposing">Parameter <see cref="IRepository{TEntity, TKey}.Dispose(bool)"/></param>
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                this.context.Dispose();
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
