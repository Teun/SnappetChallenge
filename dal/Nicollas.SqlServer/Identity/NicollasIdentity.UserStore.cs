// <copyright file="NicollasIdentity.UserStore.cs" company="Soulft">
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
    /// The Partial Identity responsible to <see cref="IUserStore{TUser}"/>
    /// </summary>
    public sealed partial class NicollasIdentity : IUserStore<User>
    {
        /// <inheritdoc/>
        Task<User> IUserStore<User>.FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            this.Logger($"FindByIdAsync(Guid userId) -> Obtain an user using an user id {userId}");
            return Task.Run(
                () =>
                {
                    return this.unitOfWork.Repository<User, Guid>().Find(Guid.Parse(userId));
                }, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            this.Logger($"FindByNameAsync(string normalizedUserName) -> Obtain an user using an normalized user name {normalizedUserName}");
            return Task.Run(
                () =>
                {
                    return this.unitOfWork.Repository<User, Guid>().FindByCriteria(u => u.NormalizedUserName == normalizedUserName);
                }, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            this.Logger($"CreateAsync(User user) -> Add a new user {user.UserName}");
            return Task.Run(
                () =>
                {
                    this.unitOfWork.Repository<User, Guid>().Add(user);
                    return IdentityResult.Success;
                }, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            this.Logger($"DeleteAsync(User user) -> Delete a new user {user.UserName}");
            return Task.Run(
                () =>
                {
                    this.unitOfWork.Repository<User, Guid>().Add(user);
                    return IdentityResult.Success;
                }, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            this.Logger($"GetNormalizedUserNameAsync(User user) -> Obtain the Normalized username of user {user.Id}");
            return Task.Run(
                () =>
                {
                    // this.unitOfWork.Repository<User, Guid>().Reload(user);
                    return user.NormalizedUserName;
                }, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            this.Logger($"GetUserIdAsync(User user) -> Obtain the userId of user {user}");
            return Task.Run(
                () =>
                {
                    // this.unitOfWork.Repository<User, Guid>().Reload(user);
                    return user.Id.ToString();
                }, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            this.Logger($"GetUserNameAsync(User user) -> Obtain the userName of user {user}");
            return Task.Run(
                () =>
                {
                    // this.unitOfWork.Repository<User, Guid>().Reload(user);
                    return user.UserName;
                }, cancellationToken);
        }

        /// <inheritdoc/>
        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            this.Logger($"SetNormalizedUserNameAsync(User user, string normalizedName) -> Sets the user normalizedName {user} {normalizedName}");
            return Task.Run(
                () =>
                {
                    user.NormalizedUserName = normalizedName;
                }, cancellationToken);
        }

        /// <inheritdoc/>
        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            this.Logger($"SetUserNameAsync(User user, string userName) -> Sets the user userName {user} {userName}");
            return Task.Run(
                () =>
                {
                    user.UserName = userName;
                }, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            this.Logger($"UpdateAsync(User user) -> Update the user {user}");
            return Task.Run(
                () =>
                {
                    this.unitOfWork.Repository<User, Guid>().Update(user);
                    return IdentityResult.Success;
                }, cancellationToken);
        }
    }
}
