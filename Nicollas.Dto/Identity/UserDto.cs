﻿//-----------------------------------------------------------------------
// <copyright file="UserDto.cs" company="Harbor Village">
//     Copyright (c) Harbor Village. All rights reserved.
// </copyright>
// <auto-generated />
// <author></author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Nicollas.Dto.Identity
{
    /// <summary>
    /// This class is a User DTO <see cref="Entities.Identity.User"/>
    /// </summary>
    public class UserDto : BaseEntityDto<Guid>
    {
        /// <summary>
        /// Gets or sets the user name for this user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the email address for this user.
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// Gets or sets the first name for this user.
        /// </summary>
        public virtual string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name for this user.
        /// </summary>
        public virtual string LastName { get; set; }

        /// <summary>
        /// Gets or sets the user password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets a navigation property for the roles this user belongs to.
        /// </summary>
        public virtual ICollection<UserRoleDto> Roles { get; set; }

        /// <summary>
        /// Gets a navigation property for the claims this user possesses.
        /// </summary>
        public virtual ICollection<UserClaimDto> Claims { get; set; }
    }
}