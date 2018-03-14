//-----------------------------------------------------------------------
// <copyright file="User.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas.Core.Entities.Identity
{
    using System;
    using System.Collections.Generic;
    using Core;
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// The User Entity
    /// </summary>
    public partial class User : IdentityUser<Guid>, IEntity<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        public User()
        {
            this.Id = Guid.NewGuid();
        }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Trash { get; set; } = false;
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        /// <param name="userName">The user name.</param>
        public User(string userName)
            : this()
        {
            this.UserName = userName;
        }

        /// <summary>
        /// Gets or sets the first name for this user.
        /// </summary>
        [Updatable]
        public virtual string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name for this user.
        /// </summary>
        [Updatable]
        public virtual string LastName { get; set; }

        /// <summary>
        /// Gets a navigation property for the roles this user belongs to.
        /// </summary>
        public virtual ICollection<UserRole> Roles { get; } = new List<UserRole>();

        /// <summary>
        /// Gets a navigation property for the claims this user possesses.
        /// </summary>
        public virtual ICollection<UserClaim> Claims { get; } = new List<UserClaim>();

        /// <summary>
        /// Gets a navigation property for the logins this user possesses.
        /// </summary>
        public virtual ICollection<UserLogin> Logins { get; } = new List<UserLogin>();


        ///// <summary>
        ///// Obtain a Claim Identity <see cref="ClaimsIdentity"/>
        ///// </summary>
        ///// <param name="manager">The User Manager class <see cref="UserManager{User, Guid}"/></param>
        ///// <param name="authenticationType">The Authentication Type</param>
        ///// <returns>A Claim Identity <see cref="ClaimsIdentity"/></returns>
        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        //{
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

        //    // Add custom user claims here
        //    return userIdentity;
        //}

        /// <summary>
        /// Gets the username for this user.
        /// </summary>
        /// <returns>The username for this user.</returns>
        public override string ToString()
        {
            return this.UserName;
        }
    }
}
