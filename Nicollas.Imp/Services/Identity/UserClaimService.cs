//-----------------------------------------------------------------------
// <copyright file="UserClaimService.cs" company="Pangom Soft">
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
    /// This class implement the generic class <see cref="Service{UserClaim, Guid}"/>and the interfaces
    /// <see cref="IUserClaimService"/>, <see cref="IService{UserClaim, Guid}"/>
    /// </summary>
    public class UserClaimService : Service<UserClaim, Guid>, IUserClaimService, IService<UserClaim, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserClaimService" /> class
        /// </summary>
        /// <param name="unitOfWork">An Unit of Work Pattern <see cref="IUnitOfWork" /> implementation</param>
        public UserClaimService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
