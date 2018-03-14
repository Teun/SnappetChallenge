//-----------------------------------------------------------------------
// <copyright file="Role.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas.Core.Entities.Identity
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// The Role Entity
    /// </summary>
    [DebuggerDisplay("Role: {Name} => {Strong}")]
    public class Role : IdentityRole<Guid>, IEntity<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Role" /> class.
        /// </summary>
        public Role()
        {
            this.Id = Guid.NewGuid();
        }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Trash { get; set; } = false;
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Role" /> class.
        /// </summary>
        /// <param name="roleName">The role name</param>
        /// <param name="strong">The strong hierarchy of the role</param>
        public Role(string roleName, float strong)
        {
            this.Name = roleName;
            this.Strong = strong;
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Gets a navigation property for the users in this role.
        /// </summary>
        public virtual ICollection<UserRole> Users { get; } = new List<UserRole>();

        /// <summary>
        /// Gets a navigation property for claims in this role.
        /// </summary>
        public virtual ICollection<RoleClaim> Claims { get; } = new List<RoleClaim>();

        /// <summary>
        /// Gets or sets the strong of this role, It means, Roles that have an strong lower than another can't see or alter it.
        /// </summary>
        public virtual float Strong { get; set; } = 0;

        /// <summary>
        /// Returns the name of the role.
        /// </summary>
        /// <returns>The name of the role.</returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}
