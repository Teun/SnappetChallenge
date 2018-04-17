// <copyright file="RoleController.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>

namespace Nicollas.Ng.Api.Admin
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Nicollas.Core.Entities.Identity;
    using Nicollas.Core.Services.Identity;
    using Nicollas.Dto.Identity;
    using Nicollas.Ng.Filters;

    /// <summary>
    /// The Controller
    /// </summary>
    public class RoleController : Controller
    {
        private IRoleService roleService;
        private IMapper mapper;
        private RoleManager<Role> mananger;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleController"/> class.
        /// </summary>
        /// <param name="roleService">Our category service</param>
        /// <param name="mananger">The Roler Mananger</param>
        /// <param name="mapper">The mapper</param>
        public RoleController(
            IRoleService roleService,
            RoleManager<Role> mananger,
            IMapper mapper)
        {
            this.roleService = roleService;
            this.mananger = mananger;
            this.mapper = mapper;
        }

        /// <summary>
        /// Read all Categorys
        /// </summary>
        /// <param name="disabled">If passed, filter by disabled status</param>
        /// <returns>List of category dto</returns>
        [HttpGet]
        public async Task<List<RoleDto>> Read(bool? disabled = null)
        {
            var tmp = await this.roleService.Entries.Include(role => role.Claims).ToListAsync();
            return this.mapper.Map<List<RoleDto>>(tmp);
        }

        /// <summary>
        /// Create an new category
        /// </summary>
        /// <param name="role">The category to be inserted</param>
        /// <returns>List of category dto</returns>
        [HttpPost]
        [AntiForgeryToken]
        public async Task<IActionResult> Create([FromBody]RoleDto role)
        {
            var identity = this.mapper.Map<Role>(role); // new Role { Name = role.Name, Strong = role.Strong };
            var result = await this.roleService.Create(identity, this.mapper.Map<List<RoleClaim>>(role.Claims).ToArray());
            if (result.Succeeded)
            {
                return this.Ok(identity.Id);
            }

            return this.BadRequest(result.Errors);
        }

        /// <summary>
        /// Update the name of an category
        /// </summary>
        /// <param name="entity">The Category Entity DTO</param>
        /// <returns>The result of operation</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]RoleDto entity)
        {
            var role = this.roleService.Find(entity.Id);
            if (role == null)
            {
                return this.NotFound();
            }

            var temp = await this.roleService.GetByCriteriaAsync(row => row.Name == entity.Name);
            if (temp != null && temp.Id != entity.Id)
            {
                return this.BadRequest("Já existe um cargo com esse nome");
            }

            role.Name = entity.Name;
            await this.roleService.UpdateAsync(role, this.mapper.Map<List<RoleClaim>>(entity.Claims));

            return this.Ok();
        }

        /// <summary>
        /// Update the name of an category
        /// </summary>
        /// <param name="entity">The Category Entity DTO</param>
        /// <returns>The result of operation</returns>
        [HttpPut]
        public async Task<IActionResult> DisableOrEnable([FromBody]RoleDto entity)
        {
            var role = this.roleService.Find(entity.Id);
            if (role == null)
            {
                return this.NotFound();
            }

            role.Disabled = !role.Disabled;
            await this.roleService.UpdateAsync(role);

            return this.Ok();
        }
    }
}
