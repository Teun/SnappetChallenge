//-----------------------------------------------------------------------
// <copyright file="BaseEntity.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas.Core.Entities
{
    using System;

    /// <summary>
    /// This class implement a <see cref="IEntity{TKey}"/>
    /// </summary>
    /// <typeparam name="TKey">The type of the key</typeparam>
    public abstract class BaseEntity<TKey> : IEntity<TKey>
    {
        /// <summary>
        /// Gets or sets the key for all the entities
        /// </summary>
        public TKey Id { get; set; }

        /// <summary>
        /// Gets or sets the create at
        /// </summary>
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the update at
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Entity is trash (should only be seen on reports)
        /// </summary>
        public bool Trash { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether the Entity is disabled (should not be seen by common users)
        /// </summary>
        public bool Disabled { get; set; } = false;
    }
}
