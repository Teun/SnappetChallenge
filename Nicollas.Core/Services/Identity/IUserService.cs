//-----------------------------------------------------------------------
// <copyright file="IUserService.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas.Core.Services.Identity
{
    using System;
    using System.Threading.Tasks;
    using Entities.Identity;
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// This class implement a <see cref="IService{User, Guid}"/>
    /// </summary>
    public interface IUserService : IService<User, Guid>
    {
        /// <summary>
        /// Sign up an user
        /// </summary>
        /// <param name="user">The user to sign up</param>
        /// <param name="password">The user password to sign up</param>
        /// <param name="role">The role that the new user is member</param>
        /// <returns>The result about how was the operation</returns>
        Task<IdentityResult> SignUp(User user, string password, string role);

        /// <summary>
        /// Send sing up confirmation
        /// </summary>
        /// <param name="user">The user to confirm</param>
        /// <param name="rootUrlConfirmation">The root url that user need to confirm</param>
        /// <returns>The result about how was the operation</returns>
        Task SendConfirmationEmail(User user, string rootUrlConfirmation);

        /// <summary>
        /// Confirm User account
        /// </summary>
        /// <param name="token">The user token confirmation</param>
        /// <param name="userId">The user id</param>
        /// <returns>The result of the inserction</returns>
        Task<IdentityResult> ConfirmAccount(string token, Guid userId);

        /// <summary>
        /// Resend sing up confirmation email
        /// </summary>
        /// <param name="user">The user to confirm</param>
        /// <param name="rootUrlConfirmation">The root url that user need to confirm</param>
        /// <returns>The result about how was the operation</returns>
        Task ResendConfirmationEmail(User user, string rootUrlConfirmation);

        /// <summary>
        /// Check if the password is right
        /// </summary>
        /// <param name="user">The user</param>
        /// <param name="password">The user password</param>
        /// <returns>The async result about how was the operation</returns>
        Task<bool> CheckPasswordAsync(User user, string password);

        /// <summary>
        /// Send token for recovery password
        /// </summary>
        /// <param name="user">The user to recovery</param>
        /// <param name="rootUrlConfirmation">The root url that user need to confirm</param>
        /// <returns>The result about how was the operation</returns>
        Task SendPasswordRecoveryEmail(User user, string rootUrlConfirmation);

        /// <summary>
        /// Send token for recovery password
        /// </summary>
        /// <param name="userid">The user id</param>
        /// <param name="token">The token to confirm user password reset</param>
        /// <param name="newPassword">New password</param>
        /// <returns>The result about how was the operation</returns>
        Task<IdentityResult> ResetPasswordAsync(Guid userid, string token, string newPassword);

        /// <summary>
        /// Reset the user password for default password if users who demand has access.
        /// </summary>
        /// <param name="supervisorId">The id of the user who demand</param>
        /// <param name="userId">The Id of the user who will have the password reset</param>
        /// <returns>The result about how was the operation</returns>
        Task<IdentityResult> SurvisorResetPasswordAsync(Guid supervisorId, Guid userId);

        /// <summary>
        /// Change user password
        /// </summary>
        /// <param name="userId">the user Id</param>
        /// <param name="oldPassword">the old password</param>
        /// <param name="newPassword">the new password</param>
        /// <returns>The result about how was the operation</returns>
        Task<IdentityResult> ChangePassword(Guid userId, string oldPassword, string newPassword);
    }
}
