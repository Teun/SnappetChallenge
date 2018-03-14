//-----------------------------------------------------------------------
// <copyright file="RoleClaimService.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas.Service.Services.Identity
{
    using System;
    using Core;
    using Core.Entities.Identity;
    using Core.Services.Identity;

    /// <summary>
    /// This class implement the generic class <see cref="Service{RoleClaim, Guid}"/>and the interfaces
    /// <see cref="IRoleClaimService"/>, <see cref="IService{RoleClaim, Guid}"/>
    /// </summary>
    public class RoleClaimService : Service<RoleClaim, Guid>, IRoleClaimService, IService<RoleClaim, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleClaimService" /> class
        /// </summary>
        /// <param name="unitOfWork">An Unit of Work Pattern <see cref="IUnitOfWork" /> implementation</param>
        public RoleClaimService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
