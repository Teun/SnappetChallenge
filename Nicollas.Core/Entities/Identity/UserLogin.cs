//-----------------------------------------------------------------------
// <copyright file="UserLogin.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas.Core.Entities.Identity
{
    using System;

    /// <summary>
    /// The User Login Entity
    /// </summary>
    public class UserLogin : BaseEntity<Guid>, IEntity<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserLogin" /> class.
        /// </summary>
        public UserLogin()
        {
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets the login provider for the login (e.g. facebook, google)
        /// </summary>
        public virtual string LoginProvider { get; set; }

        /// <summary>
        /// Gets or sets the unique provider identifier for this login.
        /// </summary>
        public virtual string ProviderKey { get; set; }

        /// <summary>
        /// Gets or sets the friendly name used in a UI for this login.
        /// </summary>
        public virtual string ProviderDisplayName { get; set; }

        /// <summary>
        /// Gets or sets the of the primary key of the user associated with this login.
        /// </summary>
        public virtual Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the user associated with this login.
        /// </summary>
        // [Newtonsoft.Json.JsonIgnore]
        public virtual User User { get; set; }
    }
}
