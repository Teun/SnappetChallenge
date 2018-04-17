//-----------------------------------------------------------------------
// <copyright file="IFactory.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas.Core
{
    using System;

    /// <summary>
    /// This interface define a Factory
    /// </summary>
    /// <typeparam name="TEntity">The Entity</typeparam>
    /// <typeparam name="TKey">The type of the key</typeparam>
    public interface IFactory<TEntity, TKey> : IDisposable
        where TEntity : class, IEntity<TKey>
    {
        /// <summary>
        /// Gets or Sets the Unit Of Work pattern <see cref="IUnitOfWork" />
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Call the dispose context
        /// </summary>
        /// <param name="disposing">If call the dispose context</param>
        void Dispose(bool disposing);
    }
}
