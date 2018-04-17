// <copyright file="TokenProviderOptions.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>
namespace Nicollas.Ng.Identity.Jwt
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.IdentityModel.Tokens;

    /// <summary>
    /// Provides options for <see cref="TokenProviderMiddleware"/>.
    /// </summary>
    public class TokenProviderOptions
    {
        /// <summary>
        /// Gets or sets the relative request path to listen on.
        /// </summary>
        /// <remarks>The default path is <c>/token</c>.</remarks>
        public string Path { get; set; } = "/token";

        /// <summary>
        ///  Gets or sets the Issuer (iss) claim for generated tokens.
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Gets or sets the Audience (aud) claim for the generated tokens.
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Gets or sets the expiration time for the generated tokens.
        /// </summary>
        /// <remarks>The default is a hour (xxxxx seconds).</remarks>
        public TimeSpan Expiration { get; set; } = TimeSpan.FromMinutes(60);

        /// <summary>
        /// Gets or sets the signing key to use when generating tokens.
        /// </summary>
        public SigningCredentials SigningCredentials { get; set; }

        /// <summary>
        /// Gets or sets resolves a user identity given a username and password.
        /// </summary>
        public Func<string, string, Task<ClaimsIdentity>> IdentityResolver { get; set; }

        /// <summary>
        /// Gets or sets generates a random value (nonce) for each generated token.
        /// </summary>
        /// <remarks>The default nonce is a random GUID.</remarks>
        public Func<Task<string>> NonceGenerator { get; set; }
            = () => Task.FromResult(Guid.NewGuid().ToString());
    }
}
