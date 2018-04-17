// <copyright file="ApplicationUserManager.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>
namespace Nicollas.Ng
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Core.Entities.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Nicollas.Core;

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    /// <summary>
    /// The UserManager for our application
    /// </summary>
    public class ApplicationUserManager : UserManager<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUserManager"/> class.
        /// </summary>
        /// <param name="store">store</param>
        /// <param name="optionsAccessor">optionsAccessor</param>
        /// <param name="passwordHasher">passwordHasher</param>
        /// <param name="userValidators">userValidators</param>
        /// <param name="passwordValidators">passwordValidators</param>
        /// <param name="keyNormalizer">keyNormalizer</param>
        /// <param name="errors">errors</param>
        /// <param name="services">services</param>
        /// <param name="logger">logger</param>
        public ApplicationUserManager(IUserStore<User> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<User> passwordHasher, IEnumerable<IUserValidator<User>> userValidators, IEnumerable<IPasswordValidator<User>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<User>> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }

        /// <inheritdoc/>
        public override Task<IdentityResult> AddClaimAsync(User user, Claim claim)
        {
            if (!claim.IsValidClaim())
            {
                return Task.FromResult(IdentityResult.Failed()); // $"Type: {claim.Type} and Value: {claim.Value} is not a valid claim"));
            }

            return base.AddClaimAsync(user, claim);
        }
    }
}
