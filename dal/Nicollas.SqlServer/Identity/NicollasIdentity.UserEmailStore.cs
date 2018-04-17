// <copyright file="NicollasIdentity.UserEmailStore.cs" company="Soulft">
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
    /// The Partial Identity responsible to <see cref="IUserEmailStore{TUser}"/>
    /// </summary>
    public sealed partial class NicollasIdentity : IUserEmailStore<User>
    {
        /// <inheritdoc/>
        public Task<User> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            this.Logger($"FindByEmailAsync(string email) -> Obtain an user using an user normalized email {normalizedEmail}");
            return this.unitOfWork.Repository<User, Guid>().GetByCriteriaAsync(u => u.NormalizedEmail == normalizedEmail);
        }

        /// <inheritdoc/>
        public Task<string> GetEmailAsync(User user, CancellationToken cancellationToken)
        {
            this.Logger($"FindByEmailAsync(string email) -> Obtain the user email of user {user.NormalizedUserName}");
            return Task.Run(
                () =>
            {
                // this.unitOfWork.Repository<User, Guid>().Reload(user);
                return user.Email;
            }, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<bool> GetEmailConfirmedAsync(User user, CancellationToken cancellationToken)
        {
            this.Logger($"GetEmailConfirmedAsync(string email) -> Obtain if the email of user {user.NormalizedUserName} is confirmed");
            return Task.Run(
                () =>
                {
                    // this.unitOfWork.Repository<User, Guid>().Reload(user);
                    return user.EmailConfirmed;
                }, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<string> GetNormalizedEmailAsync(User user, CancellationToken cancellationToken)
        {
            this.Logger($"GetNormalizedEmailAsync(string email) -> Obtain the normalized user email of user {user.NormalizedUserName}");
            return Task.Run(
                () =>
                {
                    // this.unitOfWork.Repository<User, Guid>().Reload(user);
                    return user.NormalizedUserName;
                }, cancellationToken);
        }

        /// <inheritdoc/>
        public Task SetEmailAsync(User user, string email, CancellationToken cancellationToken)
        {
            this.Logger($"SetEmailAsync(User user, string email) -> Update the user email of user {user.NormalizedUserName}");
            return Task.Run(new Action(() => user.Email = email), cancellationToken);
        }

        /// <inheritdoc/>
        public Task SetEmailConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
        {
            this.Logger($"SetEmailConfirmedAsync(User user, bool confirmed) -> Update the user email confirmed status of user {user.NormalizedUserName}");
            return Task.Run(new Action(() => user.EmailConfirmed = confirmed), cancellationToken);
        }

        /// <inheritdoc/>
        public Task SetNormalizedEmailAsync(User user, string normalizedEmail, CancellationToken cancellationToken)
        {
            this.Logger($"SetNormalizedEmailAsync(User user, string normalizedEmail) -> Update the normalizedemail of user {user.NormalizedUserName}");
            return Task.Run(new Action(() => user.NormalizedEmail = normalizedEmail), cancellationToken);
        }
    }
}
