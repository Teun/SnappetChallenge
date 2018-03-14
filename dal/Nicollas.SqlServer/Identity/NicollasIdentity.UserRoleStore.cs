// <copyright file="NicollasIdentity.UserRoleStore.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>

namespace Nicollas.SqlServer.Identity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Nicollas.Core.Entities.Identity;

    /// <summary>
    /// The Partial Identity responsible to <see cref="IUserRoleStore{TUser}"/>
    /// </summary>
    public sealed partial class NicollasIdentity : IUserRoleStore<User>
    {
        /// <inheritdoc/>
        public async Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            Role role = await this.unitOfWork.Repository<Role, Guid>().GetByCriteriaAsync(r => r.Name == roleName);
            if (role == null)
            {
                role = new Role()
                {
                    Name = roleName
                };

                this.unitOfWork.Repository<Role, Guid>().Add(role);
            }

            UserRole userRole = new UserRole()
            {
                UserId = user.Id,
                User = user,
                RoleId = role.Id,
                Role = role
            };

            this.Logger($"AddToRoleAsync(User user, string roleName) -> Add a new role into a user. " +
                        $"User {user.UserName} with Role {roleName}");

            await Task.Run(new Action(() => this.unitOfWork.Repository<UserRole, Guid>().Add(userRole)), cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
        {
            var query = from role in this.Roles.Include(r => r.Users)
                        where role.Users.Any(u => u.Id == user.Id)
                        select role.Name;

            this.Logger($"GetRolesAsync(User user) -> Obtain the list of role names using an user {user.UserName}");

            return await Task.FromResult(query.ToList());
        }

        /// <inheritdoc/>
        public Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            this.Logger($"GetUsersInRoleAsync(string roleName) -> Obtain the users in this role name {roleName}");
            return Task.Run(() =>
            {
                var query = this.Roles.Include(r => r.Users).ThenInclude(r => r.User).FirstOrDefault(r => r.NormalizedName == roleName).Users.Select(u => u.User);
                return query.ToList() as IList<User>;
            });
        }

        /// <inheritdoc/>
        public async Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            IList<string> roles = await this.GetRolesAsync(user, cancellationToken);

            this.Logger($"IsInRoleAsync(User user, string roleName) -> Obtain if the user has this role name {user.UserName} {roleName}");

            return await Task.FromResult(roles.Contains(roleName));
        }

        /// <inheritdoc/>
        public async Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            Role role = await this.unitOfWork.Repository<Role, Guid>().GetByCriteriaAsync(r => r.Name == roleName);

            this.Logger($"RemoveFromRoleAsync(User user, string roleName) -> Remove the user role {user.UserName} {roleName}");

            if (role != null)
            {
                UserRole userRole = await this.unitOfWork.Repository<UserRole, Guid>().GetByCriteriaAsync(r => r.RoleId == role.Id);

                if (userRole != null)
                {
                    this.unitOfWork.Repository<UserRole, Guid>().Delete(userRole);
                }
            }
        }
    }
}
