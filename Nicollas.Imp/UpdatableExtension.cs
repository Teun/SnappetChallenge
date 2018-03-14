// <copyright file="UpdatableExtension.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>

namespace Nicollas
{
    using System;
    using System.Linq;
    using Nicollas.Core;
    using Nicollas.Core.Entities;
    using Nicollas.Dto;

    /// <summary>
    /// Update the BaseEntity by it's DTO
    /// </summary>
    public static class UpdatableExtension
    {
        /// <summary>
        /// Update the updatable properties of entity
        /// </summary>
        /// <typeparam name="Entity">The entity to be updated</typeparam>
        /// <typeparam name="Dto">The dto to update the entity</typeparam>
        /// <param name="obj">The BaseEntity object</param>
        /// <param name="reference">the BaseEntityDto object </param>
        public static void Update<Entity, Dto>(this Entity obj, Dto reference)
            where Entity : BaseEntity<int>
            where Dto : BaseEntityDto<int>
        {
            var props = obj.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(UpdatableAttribute)));

            foreach (var prop in props)
            {
                var dtoProp = reference.GetType().GetProperty(prop.Name);
                if (dtoProp != null && dtoProp.PropertyType == prop.PropertyType)
                {
                    prop.SetValue(obj, dtoProp.GetValue(reference));
                }
            }

            obj.UpdatedAt = DateTime.Now;
        }
    }
}
