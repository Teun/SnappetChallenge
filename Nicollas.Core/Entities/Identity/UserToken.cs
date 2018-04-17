//-----------------------------------------------------------------------
// <copyright file="UserToken.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas.Core.Entities.Identity
{
    using System;

    /// <summary>
    /// The User Token Entity
    /// </summary>
    public class UserToken : BaseEntity<Guid>, IEntity<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserToken" /> class.
        /// </summary>
        public UserToken()
        {
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets the LoginProvider this token is from.
        /// </summary>
        public virtual string LoginProvider { get; set; }

        /// <summary>
        /// Gets or sets the name of the token.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the token value.
        /// </summary>
        public virtual string Value { get; set; }

        /// <summary>
        /// Gets or sets the primary key of the user that the token belongs to.
        /// </summary>
        public virtual Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the user associated with this login.
        /// </summary>
        public virtual User User { get; set; }
    }
}
