//-----------------------------------------------------------------------
// <copyright file="IDbContext.cs" company="Pangom Soft">
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
    /// This interface define a DataBase Context
    /// </summary>
    public interface IDbContext : IDisposable
    {
        /// <summary>
        /// Run required instructions to create the Database
        /// </summary>
        void CreateDataBase();

        /// <summary>
        /// Add an Entity
        /// </summary>
        /// <typeparam name="TEntity">The generic Entity</typeparam>
        /// <typeparam name="TKey">The typo of the key</typeparam>
        /// <param name="entity">The Entity</param>
        void Reload<TEntity, TKey>(TEntity entity)
            where TEntity : class, IEntity<TKey>;


        /// <summary>
        /// Provides access to change tracking and loading information for a collection navigation
        /// property that associates this entity to a collection of another entities.
        /// </summary>
        /// <typeparam name="TEntity">The Entity</typeparam>
        /// <typeparam name="TProperty">The IEnumerable property to load</typeparam>
        /// <param name="entity">Entity to work</param>
        /// <param name="propertyExpression">Expression to load the Ienumerable entity</param>
        /// <returns>An Async worker</returns>
        Task LoadCollectionAsync<TEntity, TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> propertyExpression)
             where TEntity : class, IEntity
             where TProperty : class;

        /// <summary>
        /// Provides access to change tracking and loading information for a collection navigation
        /// property that associates this entity to a collection of another entities.
        /// </summary>
        /// <typeparam name="TEntity">The Entity</typeparam>
        /// <param name="entity">Entity to work</param>
        /// <param name="propertyName">Property name to load the Ienumerable entity</param>
        /// <returns>An Async worker</returns>
        Task LoadCollectionAsync<TEntity>(TEntity entity, string propertyName)
             where TEntity : class, IEntity;

        /// <summary>
        /// Provides access to change tracking and loading information for a reference (i.e.
        /// non-collection) navigation property that associates this entity to another entity.
        /// </summary>
        /// <typeparam name="TEntity">The Entity</typeparam>
        /// <typeparam name="TProperty">The property to load</typeparam>
        /// <param name="entity">Entity to work</param>
        /// <param name="propertyExpression">Expression to load the entity</param>
        /// <returns>An Async worker</returns>
        Task LoadReferenceAsync<TEntity, TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> propertyExpression)
             where TEntity : class, IEntity
            where TProperty : class;

        /// <summary>
        /// Provides access to change tracking and loading information for a reference (i.e.
        /// non-collection) navigation property that associates this entity to another entity.
        /// </summary>
        /// <typeparam name="TEntity">The Entity</typeparam>
        /// <param name="entity">Entity to work</param>
        /// <param name="propertyName">Property Name to load the entity</param>
        /// <returns>An Async worker</returns>
        Task LoadReferenceAsync<TEntity>(TEntity entity, string propertyName)
             where TEntity : class, IEntity;

        /// <summary>
        /// Add an Entity
        /// </summary>
        /// <typeparam name="TEntity">The generic Entity</typeparam>
        /// <typeparam name="TKey">The typo of the key</typeparam>
        /// <param name="entity">The Entity</param>
        void SetAsAdded<TEntity, TKey>(TEntity entity)
            where TEntity : class, IEntity<TKey>;

        /// <summary>
        /// Update an Entity
        /// </summary>
        /// <typeparam name="TEntity">The generic Entity</typeparam>
        /// <typeparam name="TKey">The typo of the key</typeparam>
        /// <param name="entity">The Entity</param>
        void SetAsModified<TEntity, TKey>(TEntity entity)
            where TEntity : class, IEntity<TKey>;

        /// <summary>
        /// Delete an Entity
        /// </summary>
        /// <typeparam name="TEntity">The generic Entity</typeparam>
        /// <typeparam name="TKey">The typo of the key</typeparam>
        /// <param name="entity">The Entity</param>
        void SetAsDeleted<TEntity, TKey>(TEntity entity)
            where TEntity : class, IEntity<TKey>;

        /// <summary>
        /// Obtain a list of async generic Entities
        /// </summary>
        /// <param name="disabled">Include in the search disabled entities</param>
        /// <param name="trash">Include in the search trashed entities</param>
        /// <param name="asNoTracking">If True do not track the changes</param>
        /// <typeparam name="TEntity">The generic Entity</typeparam>
        /// <typeparam name="TKey">The typo of the key</typeparam>
        /// <returns>A list of async generic Entities</returns>
        Task<List<TEntity>> ToListAsync<TEntity, TKey>(bool? disabled = null, bool? trash = null, bool asNoTracking = true)
            where TEntity : class, IEntity<TKey>;

        /// <summary>
        /// Obtain a list of async generic Entities by criteria
        /// </summary>
        /// <typeparam name="TEntity">The generic Entity</typeparam>
        /// <typeparam name="TKey">The typo of the key</typeparam>
        /// <param name="predicate">A criteria</param>
        /// <param name="asNoTracking">If True do not track the changes</param>
        /// <returns>A list of async generic Entities</returns>
        Task<List<TEntity>> ToListByCriteriaAsync<TEntity, TKey>(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = true)
            where TEntity : class, IEntity<TKey>;

        /// <summary>
        /// Obtain a list query of generic Entities
        /// </summary>
        /// <typeparam name="TEntity">The generic Entity</typeparam>
        /// <typeparam name="TKey">The typo of the key</typeparam>
        /// <param name="asNoTracking">If True do not track the changes</param>
        /// <returns>A list query of generic Entities</returns>
        IQueryable<TEntity> ToQueryable<TEntity, TKey>(bool asNoTracking = true)
            where TEntity : class, IEntity<TKey>;

        /// <summary>
        /// Obtain a list query of async generic Entities
        /// </summary>
        /// <typeparam name="TEntity">The generic Entity</typeparam>
        /// <typeparam name="TKey">The typo of the key</typeparam>
        /// <param name="asNoTracking">If True do not track the changes</param>
        /// <returns>A list query of async generic Entities</returns>
        Task<IQueryable<TEntity>> ToQueryableAsync<TEntity, TKey>(bool asNoTracking = true)
            where TEntity : class, IEntity<TKey>;

        /// <summary>
        /// Obtain a list of async generic Entities Queryable by criteria
        /// </summary>
        /// <typeparam name="TEntity">The generic Entity</typeparam>
        /// <typeparam name="TKey">The typo of the key</typeparam>
        /// <param name="predicate">A criteria</param>
        /// <param name="asNoTracking">If True do not track the changes</param>
        /// <returns>A list query of async generic Entities</returns>
        Task<IQueryable<TEntity>> ToQueryableByCriteriaAsync<TEntity, TKey>(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = true)
            where TEntity : class, IEntity<TKey>;

        /// <summary>
        /// Obtain first or something async generic Entity
        /// </summary>
        /// <typeparam name="TEntity">The generic Entity</typeparam>
        /// <typeparam name="TKey">The typo of the key</typeparam>
        /// <param name="predicate">A criteria</param>
        /// <param name="asNoTracking">If True do not track the changes</param>
        /// <returns>An Entity or default</returns>
        Task<TEntity> FirstOrDefaultAsync<TEntity, TKey>(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = true)
            where TEntity : class, IEntity<TKey>;


        /// <summary>
        /// Obtain the entity by Id
        /// </summary>
        /// <typeparam name="TEntity">The generic Entity</typeparam>
        /// <typeparam name="TKey">The typo of the key</typeparam>
        /// <param name="id">The entity Id</param>
        /// <returns>An Entity</returns>
        TEntity Find<TEntity, TKey>(TKey id)
            where TEntity : class, IEntity<TKey>;

        TEntity FindByCriteria<TEntity, TKey>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : class, IEntity<TKey>;

        /// <summary>
        /// Begin an transaction
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Do a commit
        /// </summary>
        /// <returns>An identifier value</returns>
        int Commit();

        /// <summary>
        ///  Do an async commit
        /// </summary>
        /// <returns>An identifier value</returns>
        Task<int> CommitAsync();

        /// <summary>
        /// Do a rollback
        /// </summary>
        void Rollback();
    }
}
