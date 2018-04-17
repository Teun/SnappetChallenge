// <copyright file="AutoMapperExtension.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>

namespace Nicollas.Ng.Extensions
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;
    using Nicollas.Core;

    /// <summary>
    /// This class is a tool to facilite AutoMapper functions
    /// </summary>
    public static class AutoMapperExtension
    {
        /// <summary>
        /// Ignore a specific property
        /// </summary>
        /// <typeparam name="TSource">The source</typeparam>
        /// <typeparam name="TDestination">The destination</typeparam>
        /// <param name="map">mapper </param>
        /// <param name="selector">Selector</param>
        /// <returns>IMappingExpression</returns>
        public static IMappingExpression<TSource, TDestination> Ignore<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> map,
            Expression<Func<TDestination, object>> selector)
        {
            map.ForMember(selector, config => config.Ignore());
            return map;
        }

        /// <summary>
        /// Call the UoW Include before get the property
        /// </summary>
        /// <typeparam name="TSource">The source</typeparam>
        /// <typeparam name="TKey">The Source primary key</typeparam>
        /// <typeparam name="TDestination">The destination</typeparam>
        /// <param name="map">mapper </param>
        /// <returns>IMappingExpression</returns>
        public static IMappingExpression<TSource, TDestination> ForLazy<TSource, TKey, TDestination>(this IMappingExpression<TSource, TDestination> map)
        where TSource : class, Core.IEntity<TKey>
            where TDestination : class
        {
            return map.BeforeMap((entity, _) =>
            {
                using (var scope = Program.Host.Services.CreateScope())
                {
                    lock (Program.Host)
                    {
                        var services = scope.ServiceProvider;
                        var worker = services.GetRequiredService<IUnitOfWork>();

                        var oneRelation = entity.GetType().GetProperties().Where(p => p.GetMethod.IsVirtual && p.GetMethod.ReturnType.IsClass);
                        var multRelation = entity.GetType().GetProperties().Where(p => p.GetMethod.IsVirtual && p.GetMethod.ReturnType.IsArray);
                        foreach (var rlt in oneRelation)
                        {
                            worker.Repository<TSource, TKey>().LoadReference(entity, rlt.Name).Wait();
                        }
                        foreach (var rlt in multRelation)
                        {
                            worker.Repository<TSource, TKey>().LoadCollection(entity, rlt.Name).Wait();
                        }
                    }
                }
            });
        }
    }
}
