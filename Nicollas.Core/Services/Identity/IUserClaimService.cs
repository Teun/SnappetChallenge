//-----------------------------------------------------------------------
// <copyright file="IUserClaimService.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas.Core.Services.Identity
{
    using System;
    using Entities.Identity;

    /// <summary>
    /// This class implement a <see cref="IService{UserClaim, Guid}"/>
    /// </summary>
    public interface IUserClaimService : IService<UserClaim, Guid>
    {
    }
}
