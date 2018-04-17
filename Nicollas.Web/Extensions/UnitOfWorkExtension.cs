// <copyright file="UnitOfWorkExtension.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>

namespace Nicollas.Ng.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Microsoft.Extensions.DependencyInjection;
    using Nicollas.Core;

    /// <summary>
    /// Extension class to help with the EntityFramework
    /// </summary>
    public static class UnitOfWorkExtension
    {
        /// <summary>
        /// Load a reference
        /// </summary>
        /// <typeparam name="TEntity">The Entity type</typeparam>
        /// <typeparam name="TProperty">The Property type</typeparam>
        /// <param name="entity">The Entity Object</param>
        /// <param name="propertyExpression">The expression to get the Property</param>
        /// <returns>The Entity</returns>
        public static TEntity LoadReference<TEntity, TProperty>(this TEntity entity, Expression<Func<TEntity, TProperty>> propertyExpression)
            where TEntity : class, IEntity<int>
            where TProperty : class, IEntity
        {
            using (var scope = Program.Host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var worker = services.GetRequiredService<IUnitOfWork>();
                worker.Repository<TEntity, int>().LoadReference(entity, propertyExpression).Wait();
            }

            return entity;
        }

        /// <summary>
        /// Load a collection reference
        /// </summary>
        /// <typeparam name="TEntity">The Entity type</typeparam>
        /// <typeparam name="TProperty">The Property type</typeparam>
        /// <param name="entity">The Entity Object</param>
        /// <param name="propertyExpression">The expression to get the Property</param>
        /// <returns>The Entity</returns>
        public static TEntity LoadCollection<TEntity, TProperty>(this TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> propertyExpression)
            where TEntity : class, IEntity<int>
            where TProperty : class, IEntity
        {
            using (var scope = Program.Host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var worker = services.GetRequiredService<IUnitOfWork>();
                worker.Repository<TEntity, int>().LoadCollection(entity, propertyExpression).Wait();
            }

            return entity;
        }
    }
}
