// <copyright file="NicollasIdentity.UserPasswordStore.cs" company="Soulft">
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
    /// The Partial Identity responsible to <see cref="IUserPasswordStore{TUser}"/>
    /// </summary>
    public sealed partial class NicollasIdentity : IUserPasswordStore<User>
    {
        /// <inheritdoc/>
        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            this.Logger($"GetPasswordHashAsync(User user) -> Obtain the user password using an user {user.UserName}");
            return Task.Run(
                () =>
            {
                // this.unitOfWork.Repository<User, Guid>().Reload(user);
                return user.PasswordHash;
            }, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            this.Logger($"HasPasswordAsync(User user) -> Obtain if the user has password{user.UserName}");
            return Task.Run(
                () =>
                {
                    // this.unitOfWork.Repository<User, Guid>().Reload(user);
                    return !string.IsNullOrEmpty(user.PasswordHash);
                }, cancellationToken);
        }

        /// <inheritdoc/>
        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            this.Logger($"SetPasswordHashAsync(User user, string passwordHash) -> Sets the user password {user.UserName} {passwordHash}");
            return Task.Run(new Action(() => user.PasswordHash = passwordHash));
        }
    }
}
