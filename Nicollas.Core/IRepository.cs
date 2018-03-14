//-----------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// This interface defined a generic Repository
    /// </summary>
    /// <typeparam name="TEntity">The Entity</typeparam>
    /// <typeparam name="TKey">The type of the key</typeparam>
    public interface IRepository<TEntity, TKey> : IDisposable
        where TEntity :class, IEntity<TKey>
    {
        /// <summary>
        /// Gets the access for the Repository
        /// </summary>
        IQueryable<TEntity> Entries { get; }

        /// </inerhit>
        Task LoadCollection<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> propertyExpression)
            where TProperty : class;

        /// </inerhit>
        Task LoadCollection(TEntity entity, string propertyName);

        /// </inerhit>
        Task LoadReference<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> propertyExpression)
            where TProperty : class;

        /// </inerhit>
        Task LoadReference(TEntity entity, string propertyName);

        /// <summary>
        /// Obtain the async list of Entities
        /// </summary>
        /// <param name="disabled">Include in the search disabled entities</param>
        /// <param name="trash">Include in the search trashed entities</param>
        /// <returns>Async list of Entities</returns>
        Task<List<TEntity>> GetAllAsync(bool? disabled = null, bool? trash = null);

        /// <summary>
        /// Obtain the async list of Entities Queryable
        /// </summary>
        /// <returns>Async list of Entities Queryable</returns>
        Task<IQueryable<TEntity>> GetAllQueryableAsync();

        /// <summary>
        /// Obtain the async list of Entities by Criteria
        /// </summary>
        /// <param name="predicate">A criteria</param>
        /// <returns>Async list of Entities by criteria</returns>
        Task<List<TEntity>> GetAllByCriteriaAsync(Expression<Func<TEntity, bool>> predicate);


        /// <summary>
        /// Obtain the async list of Entities Queryableby Criteria
        /// </summary>
        /// <param name="predicate">A criteria</param>
        /// <returns>Async list of Entities Queryableby by criteria</returns>
        Task<IQueryable<TEntity>> GetAllQueryableByCriteriaAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Obtain the async Entity by criteria
        /// </summary>
        /// <param name="predicate">A criteria</param>
        /// <returns>Async Entity by criteria</returns>
        Task<TEntity> GetByCriteriaAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Obtain the Entity by id looking on cache first
        /// </summary>
        /// <param name="id">>The Entity id</param>
        /// <returns>Entity by id</returns>
        TEntity Find(TKey id);

        /// <summary>
        /// Obtain the Entity by criteria looking on cache first
        /// </summary>
        /// <param name="predicate">A criteria</param>
        /// <returns>Entity by criteria</returns>
        TEntity FindByCriteria(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Refresh the cached entity
        /// </summary>
        /// <param name="entity">>The Entity to refresh</param>
        void Reload(TEntity entity);

        /// <summary>
        /// Add a new Entity into the context
        /// </summary>
        /// <param name="entity">>The new Entity</param>
        void Add(TEntity entity);

        /// <summary>
        /// Update an Entity
        /// </summary>
        /// <param name="entity">The Entity</param>
        void Update(TEntity entity);

        /// <summary>
        /// Delete an Entity
        /// </summary>
        /// <param name="entity">The Entity</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Call the dispose context
        /// </summary>
        /// <param name="disposing">If call the dispose context</param>
        void Dispose(bool disposing);
    }
}
