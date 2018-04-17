//-----------------------------------------------------------------------
// <copyright file="UserService.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas.Service.Services.Identity
{
    using System;
    using System.Threading.Tasks;
    using Core;
    using Core.Entities.Identity;
    using Core.Services.Identity;
    using System.Linq;
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// This class implement the generic class <see cref="Service{User, Guid}"/> and the interfaces
    /// <see cref="IUserService"/>, <see cref="IService{User, Guid}"/>
    /// </summary>
    public class UserService : Service<User, Guid>, IUserService, IService<User, Guid>
    {
        /// <summary>
        /// The logger service <see cref="ILogger"/>
        /// </summary>
        private ILogger logger;

        /// <summary>
        /// The User Manager to handle all about the user authentication and authorization
        /// </summary>
        private UserManager<User> userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService" /> class
        /// </summary>
        /// <param name="unitOfWork">An Unit of Work Pattern <see cref="IUnitOfWork" /> implementation</param>
        /// <param name="userManager">The User Manager <see cref="UserManager{User, Guid}" /> implementation</param>
        /// <param name="logger">The logger <see cref="ILogger" /></param>
        public UserService(IUnitOfWork unitOfWork, UserManager<User> userManager, ILogger logger)
            : base(unitOfWork)
        {
            this.userManager = userManager;
            this.logger = logger;
        }

        /// <inheritdoc/>
        public async Task<IdentityResult> ConfirmAccount(string token, Guid userId)
        {
            var result = await this.userManager.ConfirmEmailAsync(this.Find(userId), token);
            if (result.Succeeded)
            {
                using (var rep = this.UnitOfWork.Repository<UserToken, Guid>())
                {
                    rep.Delete(await rep.GetByCriteriaAsync((row) => row.Value == token));
                    await this.UnitOfWork.CommitAsync();
                }
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task SendConfirmationEmail(User user, string rootUrlConfirmation)
        {
            string code = await this.userManager.GenerateEmailConfirmationTokenAsync(user);
            await this.SendConfirmationEmailAsync(user, code, rootUrlConfirmation);
            await this.UnitOfWork.CommitAsync();
        }

        /// <inheritdoc/>
        public Task<bool> CheckPasswordAsync(User user, string password)
        {
            return this.userManager.CheckPasswordAsync(user, password);
        }

        /// <inheritdoc/>
        public async Task ResendConfirmationEmail(User user, string rootUrlConfirmation)
        {
            var token = await this.UnitOfWork.Repository<UserToken, Guid>().GetByCriteriaAsync((row) => row.UserId == user.Id && row.Name == "Confirmation");
            if (token != null)
            {
                await this.SendConfirmationEmailAsync(user, token.Value, rootUrlConfirmation);
            }
        }

        /// <inheritdoc/>
        public async Task SendPasswordRecoveryEmail(User user, string rootUrlConfirmation)
        {
            string token = await this.userManager.GeneratePasswordResetTokenAsync(user);

            //await this.userManager.SendEmailAsync(
            //   user.Id,
            //   $"Password Reset",
            //   $"To reset your password, please click <a href=\"{rootUrlConfirmation}/{token}/{user.Id}\">here</a>");
            await this.UnitOfWork.CommitAsync();
        }

        /// <inheritdoc/>
        public async Task<IdentityResult> ResetPasswordAsync(Guid userid, string token, string newPassword)
        {
            var result = await this.userManager.ResetPasswordAsync(this.Find(userid), token, newPassword);
            if (result.Succeeded)
            {
                using (var rep = this.UnitOfWork.Repository<UserToken, Guid>())
                {
                    rep.Delete(await rep.GetByCriteriaAsync((row) => row.Value == token));
                    await this.UnitOfWork.CommitAsync();
                }
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<IdentityResult> SurvisorResetPasswordAsync(Guid supervisorId, Guid userId)
        {
            var supervisorUser = this.Find(supervisorId);
            var user = this.Find(userId);
            if (supervisorUser == null || user == null)
            {
                return IdentityResult.Failed(); //"User or supervisor user not found");
            }

            var supervisorBestRole = supervisorUser.Roles.Select(row => row.Role).OrderByDescending(row => row.Strong).First();
            var userBestRole = user.Roles.Select(row => row.Role).OrderByDescending(row => row.Strong).First();

            if (supervisorBestRole.Strong < userBestRole.Strong)
            {
                return IdentityResult.Failed();// "Supervisor does not have sufficient permission");
            }

            user.PasswordHash = this.userManager.PasswordHasher.HashPassword(user, "@Senha123");

            await this.UpdateAsync(user);

            return IdentityResult.Success;
        }

        /// <inheritdoc/>
        public async Task<IdentityResult> ChangePassword(Guid userId, string oldPassword, string newPassword)
        {
            var result = await this.userManager.ChangePasswordAsync(this.Find(userId), oldPassword, newPassword);
            if (result.Succeeded)
            {
                await this.UnitOfWork.CommitAsync();
            }

            return result;
        }

        /// <summary>
        /// For details <see cref="IUserService.SignUp(User, string)"/>
        /// </summary>
        /// <param name="user">Parameter user <see cref="IUserService.SignUp(User, string)"/></param>
        /// <param name="password">Parameter password <see cref="IUserService.SignUp(User, string)"/></param>
        /// <returns>Return <see cref="IUserService.SignUp(User, string)"/></returns>
        public async Task<IdentityResult> SignUp(User user, string password, string role)
        {
            if (this.userManager == null)
            {
                throw new NullReferenceException("User Manager can not be null");
            }

            user.Id = Guid.NewGuid();
            this.logger.Info = $"Registering the user {user.UserName}";
            var result = await this.userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await this.userManager.AddToRoleAsync(user, role);
                await this.UnitOfWork.CommitAsync();
            }

            return result;
        }

        private Task SendConfirmationEmailAsync(User user, string token, string rootUrlConfirmation)
        {
            return Task.FromResult(true);
            //return this.userManager.SendEmailAsync(
            //    user.Id,
            //    $"Confirm your account",
            //    $"Please confirm your account by clicking <a href=\"{rootUrlConfirmation}/?token={token}&userId={user.Id}\">here</a>");
        }
    }
}
