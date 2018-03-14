// <copyright file="NicollasIdentity.UserLoginStore.cs" company="Soulft">
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
    using Nicollas.Core.Entities.Identity;

    /// <summary>
    /// The Partial Identity responsible to <see cref="IUserLoginStore{TUser}"/>
    /// </summary>
    public sealed partial class NicollasIdentity : IUserLoginStore<User>
    {
        /// <inheritdoc/>
        public async Task AddLoginAsync(User user, UserLoginInfo login, CancellationToken cancellationToken)
        {
            UserLogin userLogin = new UserLogin()
            {
                User = user,
                UserId = user.Id,
                LoginProvider = login.LoginProvider,
                ProviderKey = login.ProviderKey
            };

            this.Logger($"AddLoginAsync(User user, UserLoginInfo login) -> Add a new Login info. " +
                        $"Provider {login.LoginProvider} and Key {login.ProviderKey} into the user {user.UserName}");

            await Task.Run(new Action(() => this.unitOfWork.Repository<UserLogin, Guid>().Add(userLogin)));
        }

        /// <inheritdoc/>
        public Task<User> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            this.Logger($"FindByLoginAsync(string loginProvider, string providerKey) -> Find a user by login info. " +
                        $"Provider {loginProvider} and Key {providerKey}");
            return Task.Run(
            () =>
            {
                var query = this.unitOfWork.Repository<UserLogin, Guid>()
                        .FindByCriteria(row => row.LoginProvider == loginProvider && row.ProviderKey == providerKey);
                return query.User;
            }, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<IList<UserLoginInfo>> GetLoginsAsync(User user, CancellationToken cancellationToken)
        {
            var query = from login in user.Logins
                        select new UserLoginInfo(login.LoginProvider, login.ProviderKey, login.ProviderDisplayName);

            this.Logger($"GetLoginsAsync(User user) -> Obtain a list of user login info using an user {user.UserName}");

            return await Task.FromResult(query.ToList());
        }

        /// <inheritdoc/>
        public async Task RemoveLoginAsync(User user, string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            UserLogin userLogin = await this.unitOfWork
               .Repository<UserLogin, Guid>().GetByCriteriaAsync(l => l.LoginProvider == loginProvider && l.ProviderKey == providerKey);

            this.Logger($"RemoveLoginAsync(User user, UserLoginInfo login) -> Remove the user login {user.UserName} {loginProvider}");

            if (userLogin != null && userLogin.User == user)
            {
                if (userLogin != null)
                {
                    this.unitOfWork.Repository<UserLogin, Guid>().Delete(userLogin);
                }
            }
        }
    }
}
