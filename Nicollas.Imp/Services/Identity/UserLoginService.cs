//-----------------------------------------------------------------------
// <copyright file="UserLoginService.cs" company="Pangom Soft">
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
    /// This class implement the generic class <see cref="Service{UserLogin, Guid}"/>and the interfaces
    /// <see cref="IUserLoginService"/>, <see cref="IService{UserLogin, Guid}"/>
    /// </summary>
    public class UserLoginService : Service<UserLogin, Guid>, IUserLoginService, IService<UserLogin, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserLoginService" /> class
        /// </summary>
        /// <param name="unitOfWork">An Unit of Work Pattern <see cref="IUnitOfWork" /> implementation</param>
        public UserLoginService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
