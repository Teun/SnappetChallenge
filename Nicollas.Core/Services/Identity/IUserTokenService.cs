//-----------------------------------------------------------------------
// <copyright file="IUserTokenService.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas.Core.Services.Identity
{
    using System;
    using Entities.Identity;

    /// <summary>
    /// This class implement a <see cref="IService{UserToken, Guid}"/>
    /// </summary>
    public interface IUserTokenService : IService<UserToken, Guid>
    {
    }
}
