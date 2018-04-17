// <copyright file="NicollasIdentity.UserClaimStore.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>

namespace Nicollas.SqlServer.Identity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Nicollas.Core.Entities.Identity;

    /// <summary>
    /// The Partial Identity responsible to <see cref="IUserClaimStore{TUser}"/>
    /// </summary>
    public sealed partial class NicollasIdentity : IUserClaimStore<User>
    {
        /// <inheritdoc/>
        public async Task AddClaimsAsync(User user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            var userClaims = new List<UserClaim>();
            foreach (var claim in claims)
            {
                userClaims.Add(new UserClaim()
                {
                    User = user,
                    UserId = user.Id,
                    ClaimType = claim.Type,
                    ClaimValue = claim.Value
                });
            }

            this.Logger($"AddClaimAsync(User user, Claim claim) -> Add {userClaims.Count} new(s) UserClaim(s) into the user {user.UserName}");

            await Task.Run(new Action(() => userClaims.ForEach(userClaim => this.unitOfWork.Repository<UserClaim, Guid>().Add(userClaim))), cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<IList<Claim>> GetClaimsAsync(User user, CancellationToken cancellationToken)
        {
            var query = from claim in user.Claims
                        select new Claim(claim.ClaimType, claim.ClaimValue);

            this.Logger($"GetClaimsAsync(User user) -> Obtain a list of claim using an user {user.UserName}");

            return await Task.FromResult(query.ToList());
        }

        /// <inheritdoc/>
        public async Task<IList<User>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
        {
            this.Logger($"GetUsersForClaimAsync(Claim claim) -> Obtain a list of users using an claim {claim}");
            return await this.unitOfWork.Repository<User, Guid>().GetAllByCriteriaAsync(row => row.Claims.Any(c => c.ClaimType == claim.Type && c.ClaimValue == claim.Value));
        }

        /// <inheritdoc/>
        public async Task RemoveClaimsAsync(User user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            foreach (var claim in claims)
            {
                UserClaim userClaim = user.Claims
               .FirstOrDefault(c => c.ClaimValue == claim.Value && c.ClaimType == claim.Type);

                this.Logger($"RemoveClaimAsync(User user, Claim claim) -> Remove the user claim {user.UserName} {claim.Issuer}");

                if (userClaim != null)
                {
                    await Task.Run(new Action(() => this.unitOfWork.Repository<UserClaim, Guid>().Delete(userClaim)));
                }
            }
        }

        /// <inheritdoc/>
        public async Task ReplaceClaimAsync(User user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
        {
            await this.RemoveClaimsAsync(user, new Claim[] { claim }, cancellationToken);
            await this.AddClaimsAsync(user, new Claim[] { newClaim }, cancellationToken);
        }
    }
}
