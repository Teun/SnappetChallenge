//-----------------------------------------------------------------------
// <copyright file="Factory.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas
{
    using System;
    using Core;

    /// <summary>
    /// This class implement <see cref="IService{TEntity, TKey}"/>
    /// </summary>
    /// <typeparam name="TEntity">A generic Entity</typeparam>
    /// <typeparam name="TKey">The type of the key</typeparam>
    public class Factory<TEntity, TKey> : IFactory<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        /// <summary>
        /// Is disposed
        /// </summary>
        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="Service{TEntity, TKey}" /> class
        /// </summary>
        /// <param name="unitOfWork">The implementation of Unit Of Work pattern <see cref="IUnitOfWork" /></param>
        public Factory(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets or Sets the Unit Of Work pattern <see cref="IUnitOfWork" />
        /// </summary>
        public IUnitOfWork UnitOfWork { get; private set; }

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
