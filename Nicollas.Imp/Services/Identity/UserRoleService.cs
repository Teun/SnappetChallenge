//-----------------------------------------------------------------------
// <copyright file="UserRoleService.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas.Service.Services.Identity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Core;
    using Core.Entities.Identity;
    using Core.Services.Identity;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This class implement the generic class <see cref="Service{UserRole, Guid}"/>and the interfaces
    /// <see cref="IUserRoleService"/>, <see cref="IService{UserRole, Guid}"/>
    /// </summary>
    public class UserRoleService : Service<UserRole, Guid>, IUserRoleService, IService<UserRole, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRoleService" /> class
        /// </summary>
        /// <param name="unitOfWork">An Unit of Work Pattern <see cref="IUnitOfWork" /> implementation</param>
        public UserRoleService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task<List<RoleClaim>> GetUserRoleClaimAsync(User user)
        {
            var roleClaim = await this.GetAllQueryableByCriteriaAsync(row => row.UserId == user.Id);
            roleClaim.Include(r => r.Role).ThenInclude(r => r.Claims);
            return roleClaim.SelectMany(r => r.Role.Claims).ToList();
        }
    }
}
