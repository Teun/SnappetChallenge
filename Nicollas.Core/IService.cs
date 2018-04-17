//-----------------------------------------------------------------------
// <copyright file="IService.cs" company="Pangom Soft">
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
    /// This interface define a Service
    /// </summary>
    /// <typeparam name="TEntity">The Entity</typeparam>
    /// <typeparam name="TKey">The type of the key</typeparam>
    public interface IService<TEntity, TKey> : IDisposable
        where TEntity : class, IEntity<TKey>
    {
        /// <summary>
        /// Gets or Sets the Unit Of Work pattern <see cref="IUnitOfWork" />
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Gets the Repository pattern <see cref="IRepository{TEntity, TKey}" />
        /// </summary>
        IRepository<TEntity, TKey> Repository { get; }

        /// <summary>
        /// Obtain the list of generic Entities Queryable
        /// </summary>
        IQueryable<TEntity> Entries { get; }

        /// <summary>
        /// Obtain the async list of generic Entities
        /// </summary>
        /// <param name="disabled">Include in the search disabled entities</param>
        /// <param name="trash">Include in the search trashed entities</param>
        /// <param name="asNoTracking">If True do not track the changes</param>
        /// <returns>The async list of generic Entities</returns>
        Task<List<TEntity>> GetAllAsync(bool? disabled = null, bool? trash = null, bool asNoTracking = true);

        /// <summary>
        /// Obtain the async list of generic Entities Queryable
        /// </summary>
        /// <param name="asNoTracking">If True do not track the changes</param>
        /// <returns>The async list of generic Entities Queryable</returns>
        Task<IQueryable<TEntity>> GetAllQueryableAsync(bool asNoTracking = true);

        /// <summary>
        /// Obtain the async list of generic Entities by Criteria
        /// </summary>
        /// <param name="predicate">The criteria</param>
        /// <param name="asNoTracking">If True do not track the changes</param>
        /// <returns>The async list of generic Entities by Criteria</returns>
        Task<List<TEntity>> GetAllByCriteriaAsync(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = true);

        /// <summary>
        /// Obtain the async list of generic Entities Queryable by Criteria
        /// </summary>
        /// <param name="predicate">The criteria</param>
        /// <param name="asNoTracking">If True do not track the changes</param>
        /// <returns>The async list of generic Entities Queryable by Criteria</returns>
        Task<IQueryable<TEntity>> GetAllQueryableByCriteriaAsync(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = true);

        /// <summary>
        /// Obtain the async list of generic Entities by a criteria
        /// </summary>
        /// <param name="predicate">The criteria</param>
        /// <param name="asNoTracking">If True do not track the changes</param>
        /// <returns>The async list of generic Entities</returns>
        Task<TEntity> GetByCriteriaAsync(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = true);

        /// <summary>
        /// Refresh the cached entity
        /// </summary>
        /// <param name="entity">The generic Entity</param>
        /// <returns>The new Entity</returns>
        TEntity Reload(TEntity entity);

        /// <summary>
        /// Add a new Entity into the repository and do a commit
        /// </summary>
        /// <param name="entity">The generic Entity</param>
        /// <returns>The new Entity</returns>
        TEntity Add(TEntity entity);

        /// <summary>
        /// Add a new Entity async into the repository and do a commit
        /// </summary>
        /// <param name="entity">The generic Entity</param>
        /// <returns>The new Entity</returns>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// Obtain the Entity by id
        /// </summary>
        /// <param name="id">>The Entity id</param>
        /// <returns>Entity by id</returns>
        TEntity Find(TKey id);

        /// <summary>
        /// Update an Entity into the repository and do a commit
        /// </summary>
        /// <param name="entity">The generic Entity</param>
        /// <returns>The updated Entity</returns>
        TEntity Update(TEntity entity);

        /// <summary>
        /// Update an Entity async into the repository and do a commit
        /// </summary>
        /// <param name="entity">The generic Entity</param>
        /// <returns>The updated Entity</returns>
        Task<TEntity> UpdateAsync(TEntity entity);

        /// <summary>
        /// Delete an Entity into the repository and do a commit
        /// </summary>
        /// <param name="entity">The generic Entity</param>
        /// <returns>The deleted Entity</returns>
        TEntity Delete(TEntity entity);

        /// <summary>
        /// Delete an Entity async into the repository and do a commit
        /// </summary>
        /// <param name="entity">The generic Entity</param>
        /// <returns>The deleted Entity</returns>
        Task<TEntity> DeleteAsync(TEntity entity);

        /// <summary>
        /// Call the dispose context
        /// </summary>
        /// <param name="disposing">If call the dispose context</param>
        void Dispose(bool disposing);
    }
}
