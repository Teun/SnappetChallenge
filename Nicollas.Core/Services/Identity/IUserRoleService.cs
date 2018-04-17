//-----------------------------------------------------------------------
// <copyright file="IUserRoleService.cs" company="Pangom Soft">
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

    /// <summary>
    /// This class implement a <see cref="IService{UserRole, Guid}"/>
    /// </summary>
    public interface IUserRoleService : IService<UserRole, Guid>
    {
        Task<List<RoleClaim>> GetUserRoleClaimAsync(User user);
    }
}
