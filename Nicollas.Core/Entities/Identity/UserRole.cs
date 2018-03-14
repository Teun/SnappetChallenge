//-----------------------------------------------------------------------
// <copyright file="UserRole.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas.Core.Entities.Identity
{
    using System;

    /// <summary>
    /// The User Role Entity
    /// </summary>
    public class UserRole : BaseEntity<Guid>, IEntity<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRole" /> class.
        /// </summary>
        public UserRole()
        {
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets the primary key of the user that is linked to a role.
        /// </summary>
        public virtual Guid UserId { get; set; }

        /// <summary>
        ///  Gets or sets the user
        /// </summary>
        //[Newtonsoft.Json.JsonIgnore]
        public virtual User User { get; set; }

        /// <summary>
        /// Gets or sets the primary key of the role that is linked to the user.
        /// </summary>
        public virtual Guid RoleId { get; set; }

        /// <summary>
        ///  Gets or sets the role
        /// </summary>
        //[Newtonsoft.Json.JsonIgnore]
        public virtual Role Role { get; set; }
    }
}
