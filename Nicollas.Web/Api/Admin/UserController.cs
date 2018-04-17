// <copyright file="UserController.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>

namespace Nicollas.Ng.Api.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Nicollas.Core;
    using Nicollas.Core.Entities.Identity;
    using Nicollas.Core.Services.Identity;
    using Nicollas.Dto.Identity;

    /// <summary>
    /// This controller class handle all about the user entity
    /// </summary>
    public class UserController : Controller
    {
        private IUserService userService;
        private IMapper mapper;
        private IPathProvider pathProvider;
        private UserManager<User> manager;
        private IRoleService roleService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="manager">The user manager</param>
        /// <param name="userService">Our user service</param>
        /// <param name="roleService">Role service</param>
        /// <param name="mapper">The mapper</param>
        /// <param name="pathProvider">The Path provider</param>
        public UserController(
            UserManager<User> manager,
            IUserService userService,
            IRoleService roleService,
            IMapper mapper,
            IPathProvider pathProvider)
        {
            this.manager = manager;
            this.userService = userService;
            this.roleService = roleService;
            this.mapper = mapper;
            this.pathProvider = pathProvider;
        }

        /// <summary>
        /// Read all Categorys
        /// </summary>
        /// <param name="disabled">If passed, filter by disabled status</param>
        /// <returns>List of category dto</returns>
        [HttpGet]
        public async Task<List<UserDto>> Read(bool? disabled = null)
        {
            var tmp = await this.userService.Entries
                .Include(user => user.Claims)
                .Include(user => user.Roles).ThenInclude(roles => roles.Role).ThenInclude(role => role.Claims)
                .ToListAsync();
            return this.mapper.Map<List<UserDto>>(tmp);
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="user">User dto</param>
        /// <param name="roleId">Role Id</param>
        /// <returns>User ID</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]UserDto user, Guid roleId)
        {
            try
            {
                User entity = this.mapper.Map<User>(user);

                var result = await this.userService.SignUp(entity, user.Password, await this.roleService.GetRoleNameById(roleId));
                if (result.Succeeded)
                {
                    return this.Ok(entity.Id);
                }

                return this.BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="user">User dto</param>
        /// <returns>User ID</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UserDto user)
        {
            try
            {
                var entity = this.userService.Find(user.Id);
                entity.FirstName = user.FirstName;
                entity.LastName = user.LastName;
                entity.UserName = user.UserName;
                var userNewRolesId = user.Roles.AsEnumerable().Select(rl => rl.RoleId);

                await this.userService.Repository.LoadCollection(entity, e => e.Roles);

                var rolesToDelete = entity.Roles.Where(row => !userNewRolesId.Any(id => id == row.RoleId))?.Select(row =>
                {
                    this.roleService.UnitOfWork.Repository<UserRole, Guid>().LoadReference(row, r => r.Role).Wait();
                    return row.Role.Name;
                }).ToArray();

                var rolesToAdd = (await this.roleService.GetAllQueryableByCriteriaAsync(row => userNewRolesId.Any(id => id == row.Id))).Select(row => row.Name).ToArray();
                await this.manager.RemoveFromRolesAsync(entity, rolesToDelete);
                await this.roleService.UnitOfWork.CommitAsync();
                await this.manager.AddToRolesAsync(entity, rolesToAdd);
                await this.roleService.UnitOfWork.CommitAsync();

                // await this.manager.UpdateSecurityStampAsync(user.Id);
                // await this.manager.UpdateAsync(entity);
                await this.userService.UpdateAsync(entity);
                return this.Ok();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Add an user to an role
        /// </summary>
        /// <param name="role">User dto</param>
        /// <returns>User ID</returns>
        [HttpPut]
        public async Task<IActionResult> AddRole([FromBody]UserRole role)
        {
            try
            {
                await this.manager.AddToRoleAsync(role.User, role.Role.Name);
                return this.Ok();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Add an user to an role
        /// </summary>
        /// <param name="role">User dto</param>
        /// <returns>User ID</returns>
        [HttpPut]
        public async Task<IActionResult> RemoveRole([FromBody]UserRoleDto role)
        {
            try
            {
                await this.manager.RemoveFromRoleAsync(await this.manager.FindByIdAsync(role.UserId.ToString()), role.Role.Name);
                return this.Ok();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Update the name of an category
        /// </summary>
        /// <param name="entity">The Category Entity DTO</param>
        /// <returns>The result of operation</returns>
        [HttpPut]
        public async Task<IActionResult> DisableOrEnable([FromBody]UserDto entity)
        {
            var temp = this.userService.Find(entity.Id);
            if (temp == null)
            {
                return this.NotFound();
            }

            temp.Disabled = !temp.Disabled;
            temp.UpdatedAt = DateTime.Now;
            await this.userService.UpdateAsync(temp);

            return this.Ok();
        }

        /// <summary>
        /// Get the user Role
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>A Action Result</returns>
        [HttpGet]
        public IActionResult GetUserRoles(Guid userId)
        {
            var user = this.userService.Find(userId);

            if (user == null)
            {
                return this.NotFound();
            }

            return this.Ok(this.mapper.Map<List<UserRoleDto>>(user.Roles));
        }

        /// <summary>
        /// Reset the Password
        /// </summary>
        /// <param name="user">The user to reset</param>
        /// <returns>An action result</returns>
        [HttpPut]
        public async Task<IActionResult> ResetPassword([FromBody]UserDto user)
        {
            var result = await this.userService.SurvisorResetPasswordAsync(Guid.Parse(this.User.FindFirst("id").Value), user.Id);
            if (result.Succeeded)
            {
                return this.Ok();
            }

            return this.BadRequest();
        }

        /// <summary>
        /// Change the Password
        /// </summary>
        /// <param name="user">The user to change</param>
        /// <param name="old">The old password</param>
        /// <returns>the New Password</returns>
        [HttpPut]
        public async Task<IActionResult> ChangePassword([FromBody]UserDto user, string old)
        {
            var result = await this.userService.ChangePassword(Guid.Parse(this.User.FindFirst("id").Value), old, user.Password);
            if (result.Succeeded)
            {
                return this.Ok();
            }

            return this.BadRequest();
        }
    }
}
