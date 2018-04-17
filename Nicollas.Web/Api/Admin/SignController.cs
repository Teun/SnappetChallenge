// <copyright file="SignController.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>

namespace Nicollas.Ng.Api.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Nicollas.Core.Entities.Identity;
    using Nicollas.Core.Services.Identity;
    using Nicollas.Dto.Identity;
    using Nicollas.Ng.Filters;
    using Nicollas.Ng.Filters.Identity;

    /// <summary>
    /// The Controller
    /// </summary>
    [AllowAnonymous]
    public class SignController : Controller
    {
        private IUserService userService;
        private IMapper mapper;
        private IConfigurationRoot configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignController"/> class.
        /// </summary>
        /// <param name="userService">Our user service</param>
        /// <param name="mapper">The mapper</param>
        /// <param name="configuration">The app settings</param>
        public SignController(IUserService userService, IMapper mapper, IConfiguration configuration)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.configuration = (IConfigurationRoot)configuration;
        }

        /// <summary>
        /// Get the email domain restrictions;
        /// </summary>
        /// <returns>The async result</returns>
        [HttpGet]
        public Task<string[]> GetEmailDomainRestriction()
        {
            return Task.Run(() => { return this.configuration.GetSection("UserSingup:EmailDomainRestriction").Value.Split(';'); });
        }

        /// <summary>
        /// Get the email domain restrictions;
        /// </summary>
        /// <returns>The async result</returns>
        [HttpGet]
        public IActionResult Logout()
        {
            return this.Ok();
        }

        /// <summary>
        /// Change the default password
        /// </summary>
        /// <param name="id">User Id</param>
        /// <param name="password">New Password</param>
        /// <returns>Response</returns>
        [HttpGet]
        public async Task<IActionResult> DefaultPassword(Guid id, string password)
        {
            var result = await this.userService.ChangePassword(id, "@Senha123", password);
            if (result.Succeeded)
            {
                return this.Ok();
            }

            return this.BadRequest(result.Errors);
        }

        /// <summary>
        /// Insert a user
        /// </summary>
        /// <param name="user">The user DTO</param>
        /// <param name="password">The user Password</param>
        /// <returns>The result of the inserction</returns>
        [HttpPost]
        [TypeFilter(typeof(ValidateSignUpFilter))]
        [AntiForgeryToken]
        public async Task<IActionResult> Singup([FromBody] UserDto user, string password)
        {
            var domains = new List<string>(this.configuration.GetSection("UserSingup:EmailDomainRestriction").Value.Split(';'));

            if (!domains.Exists((domain) => user.Email.EndsWith(domain, StringComparison.InvariantCultureIgnoreCase)))
            {
                return this.BadRequest("Email not authorized");
            }

            try
            {
                User entity = this.mapper.Map<User>(user);
                var result = await this.userService.SignUp(entity, password, "Admin");
                if (result.Succeeded)
                {
                    await this.userService.SendConfirmationEmail(entity, this.configuration.GetSection("EmailService:Callback:ConfirmAccount:ConfirmationRoute").Value);
                    return this.Ok();
                }

                return this.StatusCode(StatusCodes.Status412PreconditionFailed, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Confirm User account
        /// </summary>
        /// <param name="token">The user token confirmation</param>
        /// <param name="userId">The user id</param>
        /// <returns>The result of the inserction</returns>
        [HttpGet]
        public async Task<IActionResult> ConfirmAccount(string token, Guid userId)
        {
            try
            {
                var result = await this.userService.ConfirmAccount(token, userId);
                if (result.Succeeded)
                {
                    return this.Redirect(this.configuration.GetSection("EmailService:Callback:ConfirmAccount:SuccessConfirmationRoute").Value);
                }

                return this.NotFound(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Confirm User account
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="token">The user token confirmation</param>
        /// <param name="newPassword">new user password</param>
        /// <returns>The result of the inserction</returns>
        [HttpGet]
        public async Task<IActionResult> ResetPassword(Guid userId, string token, string newPassword)
        {
            try
            {
                var result = await this.userService.ResetPasswordAsync(userId, token, newPassword);
                if (result.Succeeded)
                {
                    return this.Ok();
                }

                return this.StatusCode(StatusCodes.Status404NotFound, result.Errors);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Resend user confirmation email
        /// </summary>
        /// <param name="username">username </param>
        /// <returns>Always return 200, doesn't matter the result</returns>
        [HttpGet]
        public async Task ResendConfirmationEmail(string username)
        {
            var user = await this.userService.GetByCriteriaAsync((row) => row.UserName == username);
            if (user == null)
            {
                return;
            }

            await this.userService.ResendConfirmationEmail(user, this.configuration.GetSection("EmailService:Callback:ConfirmAccount:ConfirmationRoute").Value);
        }

        /// <summary>
        /// Reset user information
        /// </summary>
        /// <param name="user">Informations that user known</param>
        /// <returns>The async result</returns>
        [HttpPost]
        [AntiForgeryToken]
        public async Task<IActionResult> RequestResetPassword([FromBody]UserDto user)
        {
            User entity = await this.userService.GetByCriteriaAsync((row) => row.Email == user.Email || row.UserName == user.UserName);
            if (entity == null)
            {
                return this.Ok();
            }

            try
            {
                await this.userService.SendPasswordRecoveryEmail(entity, this.configuration.GetSection("EmailService:Callback:ResetPassword:ConfirmationRoute").Value);
                return this.Ok();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
