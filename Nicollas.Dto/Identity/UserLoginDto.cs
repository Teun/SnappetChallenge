﻿//-----------------------------------------------------------------------
// <copyright file="UserLoginDto.cs" company="Harbor Village">
//     Copyright (c) Harbor Village. All rights reserved.
// </copyright>
// <auto-generated />
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas.Dto.Identity
{
    using System;

    /// <summary>
    /// This class is a UserLogin DTO <see cref="Entities.Identity.UserLogin"/>
    /// </summary>
    public class UserLoginDto
    {
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
        public virtual UserDto User { get; set; }
    }
}