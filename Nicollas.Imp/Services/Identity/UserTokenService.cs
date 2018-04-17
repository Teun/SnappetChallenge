//-----------------------------------------------------------------------
// <copyright file="UserTokenService.cs" company="Pangom Soft">
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
    /// This class implement the generic class <see cref="Service{UserToken, Guid}"/>and the interfaces
    /// <see cref="IUserTokenService"/>, <see cref="IService{UserToken, Guid}"/>
    /// </summary>
    public class UserTokenService : Service<UserToken, Guid>, IUserTokenService, IService<UserToken, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserTokenService" /> class
        /// </summary>
        /// <param name="unitOfWork">An Unit of Work Pattern <see cref="IUnitOfWork" /> implementation</param>
        public UserTokenService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
