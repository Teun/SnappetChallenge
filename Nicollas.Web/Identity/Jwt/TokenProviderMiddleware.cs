// <copyright file="TokenProviderMiddleware.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>
namespace Nicollas.Ng.Identity.Jwt
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Nicollas.Dto.Identity;
    using Nicollas.Ng.Extensions;

    /// <summary>
    /// Token generator middleware component which is added to an HTTP pipeline.
    /// This class is not created by application code directly,
    /// instead it is added by calling the <see cref="TokenProviderAppBuilderExtensions.UseSimpleTokenProvider"/>
    /// extension method.
    /// </summary>
    public class TokenProviderMiddleware
    {
        private readonly RequestDelegate next;

        private readonly TokenProviderOptions options;

        private readonly JsonSerializerSettings serializerSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenProviderMiddleware"/> class.
        /// </summary>
        /// <param name="next"><see cref="RequestDelegate"/></param>
        /// <param name="options"><see cref="IOptions{TokenProviderOptions}"/></param>
        /// <param name="loggerFactory"><see cref="ILoggerFactory"/></param>
        public TokenProviderMiddleware(RequestDelegate next, IOptions<TokenProviderOptions> options, ILoggerFactory loggerFactory)
        {
            this.next = next;
            this.options = options.Value;
            this.ThrowIfInvalidOptions(this.options);

            this.serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        /// <summary>
        /// Add a new token inside the response chain if the username and the password is correct
        /// </summary>
        /// <param name="context">The http context <see cref="HttpContext"/></param>
        /// <returns>A Task</returns>
        public Task Invoke(HttpContext context)
        {
            var user = context.User;

            // If the request path doesn't match, skip
            if (!context.Request.Path.Equals(this.options.Path, StringComparison.Ordinal))
            {
                return this.next(context);
            }

            // Request must be POST with Content-Type: application/x-www-form-urlencoded
            if (!context.Request.Method.Equals("POST") || !context.Request.HasFormContentType)
            {
                context.Response.StatusCode = 400;
                var headers = context.Response.GetTypedHeaders();
                return context.Response.WriteAsync("Bad request.");
            }

            // TODO: Insert Antiforgery token validation in header

            // _logger.LogInformation("Handling request: " + context.Request.Path);
            return this.GenerateToken(context);
        }

        /// <summary>
        /// Generate a new token
        /// </summary>
        /// <param name="context">The http context <see cref="HttpContext"/></param>
        /// <returns>A Task</returns>
        private async Task GenerateToken(HttpContext context)
        {
            var username = context.Request.Form["username"];
            var password = context.Request.Form["password"];
            ClaimsIdentity identity;

            try
            {
                identity = await this.options.IdentityResolver(username, password);
            }

            // only to validade if any error at debug time
            catch (Exception ex)
            {
                throw;
            }

            if (identity == null)
            {
                // _logger.LogInformation($"Invalid email ({email}) or password ({password})");
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid username or password.");
                return;
            }

            if (identity.FindFirst(c => c.Type == "EmailConfirmed").Value != true.ToString() && false)
            {
                // _logger.LogInformation($"User not confirmed email");
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Email not confirmed");
                return;
            }

            if (identity.FindFirst("IsDefaultPassword").Value == true.ToString())
            {
                // _logger.LogInformation($"User not confirmed email");
                context.Response.StatusCode = StatusCodes.Status406NotAcceptable;
                await context.Response.WriteAsync(identity.FindFirst("id").Value);
                return;
            }

            if (identity.FindFirst(c => c.Type == "disabled").Value == true.ToString())
            {
                // _logger.LogInformation($"Attempt to authenticate with disabled user");
                context.Response.StatusCode = StatusCodes.Status423Locked;
                await context.Response.WriteAsync("User disabled");
                return;
            }

            var now = DateTime.UtcNow;

            // Specifically add the jti (nonce), iat (issued timestamp), and sub (subject/user) claims.
            // You can add other claims here, if you want:
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, await this.options.NonceGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, this.ToUnixEpochDate(now).ToString(), ClaimValueTypes.Integer64)
            };

            var securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = identity,
                SigningCredentials = this.options.SigningCredentials,
                Audience = this.options.Audience,
                Issuer = this.options.Issuer,
                Expires = now.Add(this.options.Expiration),
                NotBefore = now
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var plainToken = tokenHandler.CreateToken(securityTokenDescriptor);
            var encodedJwt = tokenHandler.WriteToken(plainToken);
            var response = new
            {
                access_token = encodedJwt,
                expires_in = (int)this.options.Expiration.TotalSeconds,
                user_name = identity.FindFirst("firstName").Value,
                roles_claims = identity.FindFirst("RolesClaims").Value.FromJsonString<List<RoleClaimDto>>(),
                claims = identity.FindFirst("Claims").Value.FromJsonString<List<UserClaimDto>>()
            };

            // Serialize and return the response
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response, this.serializerSettings));
        }

        /// <summary>
        /// Validate Options
        /// </summary>
        /// <param name="options">The token options</param>
        private void ThrowIfInvalidOptions(TokenProviderOptions options)
        {
            if (string.IsNullOrEmpty(options.Path))
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.Path));
            }

            if (string.IsNullOrEmpty(options.Issuer))
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.Issuer));
            }

            if (string.IsNullOrEmpty(options.Audience))
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.Audience));
            }

            if (options.Expiration == TimeSpan.Zero)
            {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(TokenProviderOptions.Expiration));
            }

            if (options.IdentityResolver == null)
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.IdentityResolver));
            }

            if (options.SigningCredentials == null)
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.SigningCredentials));
            }

            if (options.NonceGenerator == null)
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.NonceGenerator));
            }
        }

        /// <summary>
        /// Get this datetime as a Unix epoch timestamp (seconds since Jan 1, 1970, midnight UTC).
        /// </summary>
        /// <param name="date">The date to convert.</param>
        /// <returns>Seconds since Unix epoch.</returns>
        private long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() -
                           new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
                          .TotalSeconds);
    }
}
