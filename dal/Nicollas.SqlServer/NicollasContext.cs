//-----------------------------------------------------------------------
// <copyright file="NicollasContext.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas.SqlServer
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Configurations;
    using Core;
    using Core.Entities.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Microsoft.EntityFrameworkCore.Storage;
    using Nicollas.Core.Entities;

    /// <summary>
    /// This class implement the interface <see cref="IDbContext" />
    /// </summary>
    public partial class NicollasContext : DbContext, IDbContext
    {
        /// <summary>
        /// A transaction Object
        /// </summary>
        private IDbContextTransaction transaction;

        private string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="NicollasContext" /> class
        /// </summary>
        /// <param name="connectionString">The connection string</param>
        /// <param name="logger">Logger handler</param>
        public NicollasContext(string connectionString, ILogger logger)
           : base()
        {
            this.connectionString = connectionString;
            if (logger != null)
            {
                // DbInterception.Add(new NicollasLogger(logger));
            }
        }

        #region DbSets

        #region Identity

        /// <summary>
        /// Gets or sets the <see cref="User" /> <see cref="DbSet{User}" />
        /// </summary>
        public virtual DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="UserClaim" /> <see cref="DbSet{UserClaim}" />
        /// </summary>
        public virtual DbSet<UserClaim> UserClaims { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="UserRole" /> <see cref="DbSet{UserRole}" />
        /// </summary>
        public virtual DbSet<UserRole> UserRoles { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Role" /> <see cref="DbSet{Role}" />
        /// </summary>
        public virtual DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="RoleClaim" /> <see cref="DbSet{RoleClaim}" />
        /// </summary>
        public virtual DbSet<RoleClaim> RoleClaims { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="UserLogin" /> <see cref="DbSet{UserLogin}" />
        /// </summary>
        public virtual DbSet<UserLogin> UserLogin { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="UserToken" /> <see cref="DbSet{UserToken}" />
        /// </summary>
        public virtual DbSet<UserToken> UserToken { get; set; }

        #endregion

        #region Evaluation

        /// <summary>
        /// Gets or sets the <see cref="User" /> <see cref="DbSet{Domain}" />
        /// </summary>
        public virtual DbSet<Domain> Domain { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="User" /> <see cref="DbSet{Subject}" />
        /// </summary>
        public virtual DbSet<Subject> Subject { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="User" /> <see cref="DbSet{Evaluation}" />
        /// </summary>
        public virtual DbSet<Evaluation> Evaluation { get; set; }
        #endregion

        #endregion

        /// <inheritdoc/>
        void IDbContext.CreateDataBase()
        {
            this.Database.Migrate();
        }

        /// <summary>
        ///  <see cref="IDbContext.Reload{TEntity, TKey}(TEntity)"/>
        ///  Reloads the entity from the database overwriting any property values with values
        ///  from the database. The entity will be in the Unchanged state after calling this
        ///  method.
        /// </summary>
        /// <typeparam name="TEntity">The Entity</typeparam>
        /// <typeparam name="TKey">The type of the key</typeparam>
        /// <param name="entity">Parameter <see cref="IDbContext.SetAsAdded{TEntity, TKey}(TEntity)"/></param>
        public void Reload<TEntity, TKey>(TEntity entity)
            where TEntity : class, IEntity<TKey>
        {
            this.Entry<TEntity>(entity).Reload();
        }

        /// <summary>
        /// <see cref="IDbContext.LoadCollectionAsync{TEntity, TProperty}(TEntity, Expression{Func{TEntity, IEnumerable{TProperty}}})"/>
        /// Provides access to change tracking and loading information for a collection navigation
        /// property that associates this entity to a collection of another entities.
        /// </summary>
        /// <typeparam name="TEntity">The Entity</typeparam>
        /// <typeparam name="TProperty">The IEnumerable property to load</typeparam>
        /// <param name="entity">Entity to work</param>
        /// <param name="propertyExpression">Expression to load the Ienumerable entity</param>
        /// <returns>An Async worker</returns>
        public Task LoadCollectionAsync<TEntity, TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> propertyExpression)
            where TEntity : class, IEntity
            where TProperty : class
        {
            return this.Entry<TEntity>(entity).Collection(propertyExpression).LoadAsync();
        }

        /// <summary>
        /// <see cref="IDbContext.LoadCollectionAsync{TEntity}(TEntity, string)"/>
        /// Provides access to change tracking and loading information for a collection navigation
        /// property that associates this entity to a collection of another entities.
        /// </summary>
        /// <typeparam name="TEntity">The Entity</typeparam>
        /// <param name="entity">Entity to work</param>
        /// <param name="propertyName">property name to load the Ienumerable entity</param>
        /// <returns>An Async worker</returns>
        public Task LoadCollectionAsync<TEntity>(TEntity entity, string propertyName)
            where TEntity : class, IEntity
        {
            return this.Entry<TEntity>(entity).Collection(propertyName).LoadAsync();
        }

        /// <summary>
        /// <see cref="IDbContext.LoadReferenceAsync{TEntity, TProperty}(TEntity, Expression{Func{TEntity, TProperty}})"/>
        /// Provides access to change tracking and loading information for a reference (i.e.
        /// non-collection) navigation property that associates this entity to another entity.
        /// </summary>
        /// <typeparam name="TEntity">The Entity</typeparam>
        /// <typeparam name="TProperty">The property to load</typeparam>
        /// <param name="entity">Entity to work</param>
        /// <param name="propertyExpression">Expression to load the entity</param>
        /// <returns>An Async worker</returns>
        public Task LoadReferenceAsync<TEntity, TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> propertyExpression)
        where TEntity : class, IEntity
            where TProperty : class
        {
            return this.Entry<TEntity>(entity).Reference(propertyExpression).LoadAsync();
        }

        /// <summary>
        /// <see cref="IDbContext.LoadReferenceAsync{TEntity}(TEntity, string)"/>
        /// Provides access to change tracking and loading information for a reference (i.e.
        /// non-collection) navigation property that associates this entity to another entity.
        /// </summary>
        /// <typeparam name="TEntity">The Entity</typeparam>
        /// <param name="entity">Entity to work</param>
        /// <param name="propertyName">Expression to load the entity</param>
        /// <returns>An Async worker</returns>
        public Task LoadReferenceAsync<TEntity>(TEntity entity, string propertyName)
        where TEntity : class, IEntity
        {
            return this.Entry<TEntity>(entity).Reference(propertyName).LoadAsync();
        }

        /// <summary>
        /// Obtain a generic Entity
        /// </summary>
        /// <typeparam name="TEntity">The Entity</typeparam>
        /// <typeparam name="TKey">The type of the key</typeparam>
        /// <returns>An Entity</returns>
        public DbSet<TEntity> Set<TEntity, TKey>()
            where TEntity : class, IEntity<TKey>
        {
            return this.Set<TEntity>();
        }

#pragma warning disable SA1124 // Do not use regions
        #region IDbContext

        /// <summary>
        /// <see cref="IDbContext.SetAsAdded{TEntity, TKey}(TEntity)"/>
        /// Add an Entity into the <see cref="DbSet{TEntity}" />
        /// </summary>
        /// <typeparam name="TEntity">The Entity</typeparam>
        /// <typeparam name="TKey">The type of the key</typeparam>
        /// <param name="entity">Parameter <see cref="IDbContext.SetAsAdded{TEntity, TKey}(TEntity)"/></param>
        public void SetAsAdded<TEntity, TKey>(TEntity entity)
#pragma warning restore SA1124 // Do not use regions
            where TEntity : class, IEntity<TKey>
        {
            this.UpdateEntityState<TEntity, TKey>(entity, EntityState.Added);
        }

        /// <summary>
        /// <see cref="IDbContext.SetAsModified{TEntity, TKey}(TEntity)"/>
        /// Update an Entity into the <see cref="DbSet{TEntity}" />
        /// </summary>
        /// <typeparam name="TEntity">The Entity</typeparam>
        /// <typeparam name="TKey">The type of the key</typeparam>
        /// <param name="entity">Parameter <see cref="IDbContext.SetAsModified{TEntity, TKey}(TEntity)"/></param>
        public void SetAsModified<TEntity, TKey>(TEntity entity)
            where TEntity : class, IEntity<TKey>
        {
            this.UpdateEntityState<TEntity, TKey>(entity, EntityState.Modified);
        }

        /// <summary>
        /// <see cref="IDbContext.SetAsDeleted{TEntity, TKey}(TEntity)"/>
        /// Remove an Entity into the <see cref="DbSet{TEntity}" />
        /// </summary>
        /// <typeparam name="TEntity">The Entity</typeparam>
        /// <typeparam name="TKey">The type of the key</typeparam>
        /// <param name="entity">Parameter <see cref="IDbContext.SetAsDeleted{TEntity, TKey}(TEntity)"/></param>
        public void SetAsDeleted<TEntity, TKey>(TEntity entity)
            where TEntity : class, IEntity<TKey>
        {
            this.UpdateEntityState<TEntity, TKey>(entity, EntityState.Deleted);
        }

        /// <summary>
        /// <see cref="IDbContext.ToListAsync{TEntity, TKey}"/>
        /// </summary>
        /// <param name="disabled">Include in the search disabled entities</param>
        /// <param name="trash">Include in the search trashed entities</param>
        /// <typeparam name="TEntity">The Entity</typeparam>
        /// <typeparam name="TKey">The type of the key</typeparam>
        /// <returns>Return <see cref="IDbContext.ToListAsync{TEntity, TKey}"/></returns>
        public Task<List<TEntity>> ToListAsync<TEntity, TKey>(bool? disabled, bool? trash)
            where TEntity : class, IEntity<TKey>
        {
            if (disabled.HasValue && trash.HasValue)
            {
                return this.Set<TEntity, TKey>().Where(row => row.Disabled == disabled && row.Trash == trash).ToListAsync();
            }

            if (disabled.HasValue)
            {
                return this.Set<TEntity, TKey>().Where(row => row.Disabled == disabled).ToListAsync();
            }

            if (trash.HasValue)
            {
                return this.Set<TEntity, TKey>().Where(row => row.Trash == trash).ToListAsync();
            }

            return this.Set<TEntity, TKey>().ToListAsync();
        }

        /// <summary>
        /// <see cref="IDbContext.ToListByCriteriaAsync{TEntity, TKey}"/>
        /// </summary>
        /// <typeparam name="TEntity">The Entity</typeparam>
        /// <typeparam name="TKey">The type of the key</typeparam>
        /// <param name="predicate">A criteria</param>
        /// <returns>Return <see cref="IDbContext.ToListByCriteriaAsync{TEntity, TKey}"/></returns>
        public Task<List<TEntity>> ToListByCriteriaAsync<TEntity, TKey>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : class, IEntity<TKey>
        {
            return this.Set<TEntity, TKey>().Where(predicate).ToListAsync<TEntity>();
        }

        /// <summary>
        /// <see cref="IDbContext.ToQueryable{TEntity, TKey}"/>
        /// </summary>
        /// <typeparam name="TEntity">The Entity</typeparam>
        /// <typeparam name="TKey">The type of the key</typeparam>
        /// <returns>Return <see cref="IDbContext.ToQueryableAsync{TEntity, TKey}"/></returns>
        public IQueryable<TEntity> ToQueryable<TEntity, TKey>()
            where TEntity : class, IEntity<TKey>
        {
            return this.Set<TEntity, TKey>().AsQueryable();
        }

        /// <summary>
        /// <see cref="IDbContext.ToQueryableAsync{TEntity, TKey}"/>
        /// </summary>
        /// <typeparam name="TEntity">The Entity</typeparam>
        /// <typeparam name="TKey">The type of the key</typeparam>
        /// <returns>Return <see cref="IDbContext.ToQueryableAsync{TEntity, TKey}"/></returns>
        public Task<IQueryable<TEntity>> ToQueryableAsync<TEntity, TKey>()
            where TEntity : class, IEntity<TKey>
        {
            return Task.FromResult(this.Set<TEntity, TKey>().AsQueryable());
        }

        /// <summary>
        /// <see cref="IDbContext.ToQueryableByCriteriaAsync{TEntity, TKey}"/>
        /// </summary>
        /// <typeparam name="TEntity">The Entity</typeparam>
        /// <typeparam name="TKey">The type of the key</typeparam>
        /// <param name="predicate">A criteria</param>
        /// <returns>Return <see cref="IDbContext.ToQueryableByCriteriaAsync{TEntity, TKey}"/></returns>
        public Task<IQueryable<TEntity>> ToQueryableByCriteriaAsync<TEntity, TKey>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : class, IEntity<TKey>
        {
            return Task.FromResult(this.Set<TEntity, TKey>().Where(predicate).AsQueryable());
        }

        /// <summary>
        /// <see cref="IDbContext.FirstOrDefaultAsync{TEntity, TKey}(Expression{Func{TEntity, bool}})"/>
        /// </summary>
        /// <typeparam name="TEntity">The Entity</typeparam>
        /// <typeparam name="TKey">The type of the key</typeparam>
        /// <param name="predicate">Parameter <see cref="IDbContext.FirstOrDefaultAsync{TEntity, TKey}(Expression{Func{TEntity, bool}})"/></param>
        /// <returns>Return <see cref="IDbContext.FirstOrDefaultAsync{TEntity, TKey}(Expression{Func{TEntity, bool}})"/></returns>
        public Task<TEntity> FirstOrDefaultAsync<TEntity, TKey>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : class, IEntity<TKey>
        {
            return this.Set<TEntity, TKey>().FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// <see cref="Find{TEntity, TKey}"/>
        /// </summary>
        /// <typeparam name="TEntity">The Entity</typeparam>
        /// <typeparam name="TKey">The type of the key</typeparam>
        /// <param name="id">Parameter <see cref="Find{TEntity, TKey}"/></param>
        /// <returns>Return <see cref="Find{TEntity, TKey}"/></returns>
        public TEntity Find<TEntity, TKey>(TKey id)
            where TEntity : class, IEntity<TKey>
        {
            return this.Set<TEntity, TKey>().Find(id);
        }

        /// <inheritdoc/>
        public TEntity FindByCriteria<TEntity, TKey>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : class, IEntity<TKey>
        {
            return this.Set<TEntity, TKey>().Local.AsQueryable().FirstOrDefault(predicate) ?? this.FirstOrDefaultAsync<TEntity, TKey>(predicate).Result;
        }

        /// <summary>
        /// <see cref="IDbContext.BeginTransaction"/>
        /// Begin an Entity Framework DataBase transaction
        /// </summary>
        public void BeginTransaction()
        {
            if (this.Database.GetDbConnection().State == ConnectionState.Open)
            {
                return;
            }

            this.Database.OpenConnection();
            this.transaction = this.Database.BeginTransaction();
        }

        /// <summary>
        /// <see cref="IDbContext.Commit"/>
        /// Do a commit into Entity Framework DataBase
        /// </summary>
        /// <returns>Return <see cref="IDbContext.Commit"/></returns>
        public int Commit()
        {
            try
            {
                this.BeginTransaction();
                var saveChanges = this.SaveChanges();
                this.EndTransaction();

                return saveChanges;
            }
            catch (Exception)
            {
                this.Rollback();
                throw;
            }
            finally
            {
                // base.Dispose();
            }
        }

        /// <summary>
        /// <see cref="IDbContext.CommitAsync"/>
        /// Do an async commit into Entity Framework DataBase
        /// </summary>
        /// <returns>Return <see cref="IDbContext.CommitAsync"/></returns>
        public async Task<int> CommitAsync()
        {
            try
            {
                this.BeginTransaction();
                var saveChangesAsync = await this.SaveChangesAsync();
                this.EndTransaction();

                return saveChangesAsync;
            }
            catch (Exception)
            {
                this.Rollback();
                throw;
            }
            finally
            {
                // base.Dispose();
            }
        }

        /// <summary>
        /// <see cref="IDbContext.Rollback"/>
        /// Rollback an Entity Framework transaction
        /// </summary>
        public void Rollback()
        {
            if (this.transaction != null && this.transaction.TransactionId != Guid.Empty)
            {
                this.transaction.Rollback();
            }
        }

        /// <summary>
        /// Override the base dispose
        /// </summary>
        public new void Dispose()
        {
            // base.Dispose();
        }

        /// <summary>
        /// Fill the CreatedAt and UpdatedAt fields automatically
        /// </summary>
        /// <param name="cancellationToken">The async cancelation token</param>
        /// <returns>An Identifier</returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.HandleTrackers();
            return base.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Fill the CreatedAt and UpdatedAt fields automatically
        /// </summary>
        /// <returns>An Identifier</returns>
        public override int SaveChanges()
        {
            this.HandleTrackers();
            return base.SaveChanges();
        }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseMySQL(this.connectionString); // OFICIAL MYSQL THAT IS ACTUALLY BROKEN
            optionsBuilder.UseMySql(this.connectionString); // POMELO ADDAPTER TO WORKARROUNT
        }

        /// <summary>
        /// Call each configuration entity
        /// </summary>
        /// <param name="modelBuilder">Entity Framework Model Builder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserClaimConfiguration());
            modelBuilder.ApplyConfiguration(new RoleClaimConfiguration());
            modelBuilder.ApplyConfiguration(new UserLoginConfiguration());
            modelBuilder.ApplyConfiguration(new UserTokenConfiguration());
        }

        /// <summary>
        /// Finish a transaction
        /// </summary>
        private void EndTransaction()
        {
            if (this.transaction != null && this.transaction.TransactionId != Guid.Empty)
            {
                this.transaction.Commit();
                this.Database.CloseConnection(); // GetDbConnection().Close();
            }
        }

        /// <summary>
        /// Update the Entity State
        /// </summary>
        /// <typeparam name="TEntity">The type of the Entity</typeparam>
        /// <typeparam name="TKey">The type of the key</typeparam>
        /// <param name="entity">The Entity</param>
        /// <param name="entityState">The new State</param>
        private void UpdateEntityState<TEntity, TKey>(TEntity entity, EntityState entityState)
            where TEntity : class, IEntity<TKey>
        {
            var entityEntry = this.GetDbEntityEntrySafely<TEntity, TKey>(entity);
            if (entityEntry.State == EntityState.Unchanged)
            {
                entityEntry.State = entityState;
            }
        }

        /// <summary>
        /// Obtain the Entity Entry
        /// </summary>
        /// <typeparam name="TEntity">The type of the Entity</typeparam>
        /// <typeparam name="TKey">The type of the key</typeparam>
        /// <param name="entity">The Entity</param>
        /// <returns>The Entity Entry</returns>
        private EntityEntry GetDbEntityEntrySafely<TEntity, TKey>(TEntity entity)
            where TEntity : class, IEntity<TKey>
        {
            var entityEntry = this.Entry<TEntity>(entity);
            if (entityEntry.State == EntityState.Detached)
            {
                this.Set<TEntity, TKey>().Attach(entity);
            }

            return entityEntry;
        }

        /// <summary>
        /// Update Created and Updated fields and initialize Guid Ids before save or update
        /// </summary>
        private void HandleTrackers()
        {
            var entities = this.ChangeTracker.Entries().Where(x => x.Entity is IEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    if (entity.Entity is IEntity<Guid> && (((IEntity<Guid>)entity.Entity).Id == null || ((IEntity<Guid>)entity.Entity).Id == Guid.Empty))
                    {
                        ((IEntity<Guid>)entity.Entity).Id = Guid.NewGuid();
                    }

                    ((IEntity)entity.Entity).CreatedAt = DateTime.UtcNow;
                }

                if (entity.State == EntityState.Modified)
                {
                    ((IEntity)entity.Entity).UpdatedAt = DateTime.UtcNow;
                }
            }
        }

        #endregion
    }
}
