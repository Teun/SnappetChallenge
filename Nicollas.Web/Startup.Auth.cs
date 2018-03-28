// <copyright file="Startup.Auth.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>
namespace Nicollas
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Security.Principal;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using Newtonsoft.Json;
    using Nicollas.Core;
    using Nicollas.Core.Entities.Identity;
    using Nicollas.Core.Services.Identity;
    using Nicollas.Ng.Extensions;
    using Nicollas.Ng.Identity.Jwt;

    /// <summary>
    /// The Authentication Boostraper
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// Configuration on the authentication jwt
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/></param>
        private void ConfigureAuth(IServiceCollection services)
        {
            var securityKey = this.Configuration["SecurityKey"];
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(securityKey));

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;

                // Valida a assinatura de um token recebido
                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.IssuerSigningKey = signingKey;

                paramsValidation.ValidateIssuer = true;
                paramsValidation.ValidIssuer = "NicollasHV";

                paramsValidation.ValidateAudience = true;
                paramsValidation.ValidAudience = "http://www.Nicollashv.com";

                // Verifica se um token recebido ainda é válido
                paramsValidation.ValidateLifetime = true;

                // Tempo de tolerância para a expiração de um token (utilizado
                // caso haja problemas de sincronismo de horário entre diferentes
                // computadores envolvidos no processo de comunicação)
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            // Ativa o uso do token como forma de autorizar o acesso
            // a recursos deste projeto
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });
        }

        private void AddTokenProvider(IApplicationBuilder app)
        {
            var securityKey = this.Configuration["SecurityKey"];
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(securityKey));

            UserManager<User> userManager = (UserManager<User>)app.ApplicationServices.GetService(typeof(UserManager<User>));
            IUserService userService = (IUserService)app.ApplicationServices.GetService(typeof(IUserService));

            app.UseSimpleTokenProvider(new TokenProviderOptions
            {
                Path = "/token",
                Audience = "http://www.Nicollashv.com",
                Issuer = "NicollasHV",
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                IdentityResolver = (username, password) => this.GetIdentity(app.ApplicationServices, username, password)
            });
        }

        /// <summary>
        /// Obtain an Identity <see cref="ClaimsIdentity"/>
        /// </summary>
        /// <param name="provider">The Service provider used to get all services injected on the app</param>
        /// <param name="username">The username to verify</param>
        /// <param name="password">The password to verify</param>
        /// <returns>An Identity</returns>
        private async Task<ClaimsIdentity> GetIdentity(IServiceProvider provider, string username, string password)
        {
            UserManager<User> userManager = (UserManager<User>)provider.GetService(typeof(UserManager<User>));
            IUserRoleService roleService = (IUserRoleService)provider.GetService(typeof(IUserRoleService));
            var uow = (IUnitOfWork)provider.GetService(typeof(IUnitOfWork));

            var user = userManager.Users.FirstOrDefault(row => row.UserName.ToLower() == username.ToLower());  // await userManager.FindByNameAsync(username); // -- getting from cache is not safe
            if (user == null)
            {
                return null;
            }

            uow.Repository<User, Guid>().Reload(user);

            // to refresh email confirmation
            var emailConfirmed = user.EmailConfirmed ? true : (await userManager.IsEmailConfirmedAsync(user));
            var isDefaultPassword = password.Equals("@Senha123");

            var result = await userManager.CheckPasswordAsync(user, password);
            if (!result || user.Trash)
            {
                return null;
            }

            // var dbg = uow.Repository<Role, Guid>().Entries.Include(r => r.Claims).Include(r => r.Users).ThenInclude(ur => ur.User).ToList();
            var roleClaims = await roleService.GetUserRoleClaimAsync(user);

           var claims = new[]
            {
                new Claim("username", user.UserName),
                new Claim("firstName", user.FirstName),
                new Claim("disabled", user.Disabled.ToString()),
                new Claim("email", user.Email ?? string.Empty),
                new Claim("id", user.Id.ToString()),
                new Claim("EmailConfirmed", emailConfirmed.ToString()),
                new Claim("IsDefaultPassword", isDefaultPassword.ToString()),
                new Claim("RolesClaims", roleClaims.ToJsonString(ReferenceLoopHandling.Ignore)),
                new Claim("Claims", user.Claims.ToJsonString(ReferenceLoopHandling.Ignore))
            };
            return new ClaimsIdentity(new GenericIdentity(username, "Token"), claims);
        }
    }
}
