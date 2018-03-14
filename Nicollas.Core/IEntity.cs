//-----------------------------------------------------------------------
// <copyright file="IEntity.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas.Core
{
    using System;

    /// <summary>
    /// This interface define an Entity
    /// </summary>
    /// <typeparam name="TKey">The type of the key</typeparam>
    public interface IEntity<TKey> : IEntity
    {
        /// <summary>
        /// Gets or sets the key for all the entities
        /// </summary>
        TKey Id { get; set; }
       
    }

    public interface IEntity
    {
        /// <summary>
        /// Gets or sets the create at
        /// </summary>
        DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the update at
        /// </summary>
        DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Entity is trash (should only be seen on reports)
        /// </summary>
        bool Trash { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Entity is disabled (should not be seen by common users)
        /// </summary>
        bool Disabled { get; set; }
    }
}
