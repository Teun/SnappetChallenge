// <copyright file="UserTokenProvider.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>

namespace Nicollas.Providers.Identity
{
    using System;
    using System.Threading.Tasks;
    using Nicollas.Core;
    using Nicollas.Core.Entities.Identity;
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// This class implements <see cref="IUserTokenProvider{User, Guid}"/>
    /// </summary>
    public class UserTokenProvider // : IUserTokenProvider<User>
    {
        private IDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserTokenProvider"/> class.
        /// </summary>
        /// <param name="context">The IDbContext</param>
        public UserTokenProvider(IDbContext context)
        {
            this.context = context;
        }

        /// <inheritdoc/>
        public async Task<string> GenerateAsync(string purpose, UserManager<User> manager, User user)
        {
            var entity = await this.context.FirstOrDefaultAsync<UserToken, Guid>((row) => row.Name == purpose && row.UserId == user.Id);
            if (entity != null)
            {
                this.context.SetAsDeleted<UserToken, Guid>(entity);
            }

            UserToken userToken = new UserToken
            {
                CreatedAt = DateTime.Now,
                Id = Guid.NewGuid(),
                LoginProvider = "UserTokenProvider",
                Name = purpose,
                UserId = user.Id,
                Value = Guid.NewGuid().ToString()
            };
            this.context.SetAsAdded<UserToken, Guid>(userToken);
            return userToken.Value;
        }

        /// <inheritdoc/>
        public Task<bool> IsValidProviderForUserAsync(UserManager<User> manager, User user)
        {
            if (manager == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return Task.FromResult<bool>(manager.SupportsUserPassword);
            }
        }

        /// <inheritdoc/>
        public Task NotifyAsync(string token, UserManager<User> manager, User user)
        {
            return Task.FromResult<int>(0);
        }

        /// <inheritdoc/>
        public async Task<bool> ValidateAsync(string purpose, string token, UserManager<User> manager, User user)
        {
            var tmp = await this.context.FirstOrDefaultAsync<UserToken, Guid>((row) => row.Value == token && row.Name == purpose && row.UserId == user.Id);
            return tmp != null;
        }
    }
}
