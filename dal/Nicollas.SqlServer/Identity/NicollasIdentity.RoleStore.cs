// <copyright file="NicollasIdentity.RoleStore.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>

namespace Nicollas.SqlServer.Identity
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Nicollas.Core.Entities.Identity;

    /// <summary>
    /// Implementation of <see cref="IRoleStore{TRole}"/>
    /// </summary>
    public sealed partial class NicollasIdentity : IRoleStore<Role>
    {
        /// <inheritdoc/>
        public Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
        {
            this.Logger($"CreateAsync(Role role) -> Add a new role {role.Name}");

            return Task.Run(
                () =>
            {
                this.unitOfWork.Repository<Role, Guid>().Add(role);
                return IdentityResult.Success;
            }, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
        {
            this.Logger($"DeleteAsync(Role role) -> Delete a role {role.Name}");
            return Task.Run(
            () =>
            {
                this.unitOfWork.Repository<Role, Guid>().Delete(role);
                return IdentityResult.Success;
            }, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            this.Logger($" GetNormalizedRoleNameAsync(Role role) -> Gets a  normalized role name {role.Id}");
            return Task.Run(
            () =>
            {
                this.unitOfWork.Repository<Role, Guid>().Reload(role);
                return role.NormalizedName;
            }, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
        {
            this.Logger($" GetRoleIdAsync(Role role) -> Gets a role Id {role.Name}");
            return Task.Run(
            () =>
            {
                this.unitOfWork.Repository<Role, Guid>().Reload(role);
                return role.Id.ToString();
            }, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            this.Logger($" GetRoleNameAsync(Role role) -> Gets a role name {role.Name}");
            return Task.Run(
            () =>
            {
                this.unitOfWork.Repository<Role, Guid>().Reload(role);
                return role.Name;
            }, cancellationToken);
        }

        /// <inheritdoc/>
        public Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
        {
            this.Logger($"SetNormalizedRoleNameAsync(Role role, string normalizedName) -> Sets the normalized role name {normalizedName} on the role {role.Id}");
            return Task.Run(new Action(() => role.NormalizedName = normalizedName), cancellationToken);
        }

        /// <inheritdoc/>
        public Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
        {
            this.Logger($"SetRoleNameAsync(Role role, string roleName) -> Sets the role name {roleName} on the role {role.Id}");
            return Task.Run(new Action(() => role.Name = roleName), cancellationToken);
        }

        /// <inheritdoc/>
        public Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
        {
            this.Logger($"UpdateAsync(Role role, string roleName) -> Update the role {role.Name}");
            return Task.Run(
            () =>
            {
                this.unitOfWork.Repository<Role, Guid>().Update(role);
                return IdentityResult.Success;
            }, cancellationToken);
        }

        /// <inheritdoc/>
        Task<Role> IRoleStore<Role>.FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            this.Logger($"FindByIdAsync(string roleId) -> Find the role by Id {roleId}");
            return Task.Run(
            () =>
            {
                return this.unitOfWork.Repository<Role, Guid>().Find(Guid.Parse(roleId));
            }, cancellationToken);
        }

        /// <inheritdoc/>
        Task<Role> IRoleStore<Role>.FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            this.Logger($"FindByNameAsync(string normalizedRoleName) -> Find the role by normalized name {normalizedRoleName}");
            return Task.Run(
            () =>
            {
                return this.unitOfWork.Repository<Role, Guid>().FindByCriteria(r => r.NormalizedName == normalizedRoleName);
            }, cancellationToken);
        }
    }
}
