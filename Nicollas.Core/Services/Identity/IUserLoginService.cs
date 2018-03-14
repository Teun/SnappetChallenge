//-----------------------------------------------------------------------
// <copyright file="IUserLoginService.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas.Core.Services.Identity
{
    using System;
    using Entities.Identity;

    /// <summary>
    /// This class implement a <see cref="IService{UserLogin, Guid}"/>
    /// </summary>
    public interface IUserLoginService : IService<UserLogin, Guid>
    {
    }
}
