//-----------------------------------------------------------------------
// <copyright file="RoleService.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas.Service.Services.Identity
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Core;
    using Core.Entities.Identity;
    using Core.Services.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This class implement the generic class <see cref="Service{Role, Guid}"/>and the interfaces
    /// <see cref="IRoleService"/>, <see cref="IService{Role, Guid}"/>
    /// </summary>
    public class RoleService : Service<Role, Guid>, IRoleService, IService<Role, Guid>
    {
        private RoleManager<Role> roleManager;
        private ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleService" /> class
        /// </summary>
        /// <param name="unitOfWork">An Unit of Work Pattern <see cref="IUnitOfWork" /> implementation</param>
        /// <param name="roleManager">The role manager</param>
        /// <param name="logger">the logger</param>
        public RoleService(IUnitOfWork unitOfWork, RoleManager<Role> roleManager, ILogger logger)
            : base(unitOfWork)
        {
            this.roleManager = roleManager;
            this.logger = logger;
        }

        /// <summary>
        /// For details <see cref="IUserService.SignUp(User, string)"/>
        /// </summary>
        /// <param name="role">The role to be added</param>
        /// <param name="claims">The claims of the role</param>
        /// <returns>Return <see cref="IUserService.SignUp(User, string)"/></returns>
        public async Task<IdentityResult> Create(Role role, params RoleClaim[] claims)
        {
            if (this.roleManager == null)
            {
                throw new NullReferenceException("Role Manager can not be null");
            }

            if (await this.roleManager.RoleExistsAsync(role.Name))
            {
                return IdentityResult.Failed(); // "Já existe um cargo com esse nome");
            }

            this.logger.Info = $"Registering the role {role.Name}";

            role.Id = Guid.NewGuid();
            var result = await this.roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                foreach (var claim in claims)
                {
                    if (claim.ToClaim().IsValidClaim())
                    {
                        role.Claims.Add(claim);
                    }
                }

                await this.roleManager.UpdateAsync(role);
                await this.UnitOfWork.CommitAsync();
            }

            return result;
        }

        public override Task<List<Role>> GetAllAsync(bool? disabled = null, bool? trash = null)
        {
            return this.Entries.Include(r => r.Claims).ThenInclude(c => c.Role).AsNoTracking().ToListAsync();
        }

        public async Task<string> GetRoleNameById(Guid id)
        {
            return (await this.Entries.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id))?.Name;
        }

        public async Task UpdateAsync(Role role, List<RoleClaim> claims)
        {
            await this.Repository.LoadCollection(role, r => r.Claims);
            role.Claims.Clear();
            foreach (var claim in claims)
            {
                if (claim.ToClaim().IsValidClaim())
                {
                    role.Claims.Add(claim);
                }
            }

            await this.roleManager.UpdateAsync(role);
            await this.UnitOfWork.CommitAsync();
        }
    }
}
