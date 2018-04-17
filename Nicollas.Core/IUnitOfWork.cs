//-----------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas.Core
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// This interface define an Unit Of Work pattern
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Obtain a generic repository
        /// </summary>
        /// <typeparam name="TEntity">The Entity</typeparam>
        /// <typeparam name="TKey">The type of the key</typeparam>
        /// <returns>A generic repository</returns>
        IRepository<TEntity, TKey> Repository<TEntity, TKey>()
            where TEntity : class, IEntity<TKey>;

        /// <summary>
        /// Begin a context transaction
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Do the context commit
        /// </summary>
        /// <returns>An identifier value</returns>
        int Commit();

        /// <summary>
        /// Do the context commit async
        /// </summary>
        /// <returns>An identifier value</returns>
        Task<int> CommitAsync();

        /// <summary>
        /// Rollback the context transaction
        /// </summary>
        void Rollback();

        /// <summary>
        /// Call the dispose context
        /// </summary>
        /// <param name="disposing">If call the dispose context</param>
        void Dispose(bool disposing);
    }
}
