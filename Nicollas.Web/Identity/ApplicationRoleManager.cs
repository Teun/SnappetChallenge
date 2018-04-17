// <copyright file="ApplicationRoleManager.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>
namespace Nicollas.Ng
{
    using System.Collections.Generic;
    using Core.Entities.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    /// <summary>
    /// The UserManager for our application
    /// </summary>
    public class ApplicationRoleManager : RoleManager<Role>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationRoleManager"/> class.
        /// </summary>
        /// <param name="store">store</param>
        /// <param name="roleValidators">roleValidators</param>
        /// <param name="keyNormalizer">keyNormalizer</param>
        /// <param name="errors">errors</param>
        /// <param name="logger">logger</param>
        public ApplicationRoleManager(IRoleStore<Role> store, IEnumerable<IRoleValidator<Role>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<Role>> logger)
            : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }
}
