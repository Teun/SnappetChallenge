//-----------------------------------------------------------------------
// <copyright file="UnitOfWork.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas
{
    using System;
    using System.Collections;
    using System.Threading.Tasks;
    using Core;

    /// <summary>
    /// This class implement the Unit Of Work pattern <see cref="IUnitOfWork"/>
    /// </summary>
    public class UnitOfWork : IUnitOfWork
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
        /// A hash of repositories
        /// </summary>
        private Hashtable repositories;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork" /> class
        /// </summary>
        /// <param name="context">The implementation of Database Context <see cref="IDbContext" /></param>
        public UnitOfWork(IDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// <see cref="IUnitOfWork.Repository{TEntity, TKey}"/>
        /// </summary>
        /// <typeparam name="TEntity">The Entity</typeparam>
        /// <typeparam name="TKey">The type of the key</typeparam>
        /// <returns>Return <see cref="IUnitOfWork.Repository{TEntity, TKey}"/></returns>
        public IRepository<TEntity, TKey> Repository<TEntity, TKey>()
            where TEntity : class, IEntity<TKey>
        {
            if (this.repositories == null)
            {
                this.repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (this.repositories.ContainsKey(type))
            {
                return (IRepository<TEntity, TKey>)this.repositories[type];
            }

            var repositoryType = typeof(Nicollas.Repository<TEntity, TKey>);

            this.repositories.Add(type, Activator.CreateInstance(repositoryType, this.context));

            return (IRepository<TEntity, TKey>)this.repositories[type];
        }

        /// <summary>
        /// <see cref="IUnitOfWork.BeginTransaction"/>
        /// </summary>
        public void BeginTransaction()
        {
            this.context.BeginTransaction();
        }

        /// <summary>
        /// <see cref="IUnitOfWork.Commit"/>
        /// </summary>
        /// <returns>Return <see cref="IUnitOfWork.Commit"/></returns>
        public int Commit()
        {
            return this.context.Commit();
        }

        /// <summary>
        /// <see cref="IUnitOfWork.CommitAsync"/>
        /// </summary>
        /// <returns>Return <see cref="IUnitOfWork.CommitAsync"/></returns>
        public Task<int> CommitAsync()
        {
            return this.context.CommitAsync();
        }

        /// <summary>
        /// <see cref="IUnitOfWork.Rollback"/>
        /// </summary>
        public void Rollback()
        {
            this.context.Rollback();
        }

        /// <summary>
        /// <see cref="IUnitOfWork.Dispose(bool)"/>
        /// </summary>
        /// <param name="disposing">Parameter <see cref="IUnitOfWork.Dispose(bool)"/></param>
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                this.context.Dispose();
                if (this.repositories != null)
                {
                    foreach (IDisposable repository in this.repositories?.Values)
                    {
                        repository.Dispose();
                    }
                }
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
