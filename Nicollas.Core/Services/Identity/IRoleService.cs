//-----------------------------------------------------------------------
// <copyright file="IRoleService.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas.Core.Services.Identity
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities.Identity;
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// This class implement a <see cref="IService{Role, Guid}"/>
    /// </summary>
    public interface IRoleService : IService<Role, Guid>
    {
        /// <summary>
        /// Create an new role
        /// </summary>
        /// <param name="role">role</param>
        /// <param name="claims">The claims of the role</param>
        /// <returns>Async work with result</returns>
        Task<IdentityResult> Create(Role role, params RoleClaim[] claims);

        /// <summary>
        /// Update the role and refresh the claims
        /// </summary>
        /// <param name="role">Role to update</param>
        /// <param name="claims">New claims</param>
        /// <returns></returns>
        Task UpdateAsync(Role role, List<RoleClaim> claims);

        Task<string> GetRoleNameById(Guid id);
    }

}
