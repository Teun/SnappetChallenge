// <copyright file="MappingProfile.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>
namespace Nicollas.Ng
{
    using AutoMapper;
    using Nicollas.Core.Entities.Identity;
    using Nicollas.Dto.Identity;
    using Nicollas.Ng.Extensions;

    /// <summary>
    /// The mapping profile. Map all DTOs
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            // Identity
            this.CreateMap<Role, RoleDto>().ReverseMap();
            this.CreateMap<RoleClaim, RoleClaimDto>().Ignore(p => p.Role).ReverseMap();
            this.CreateMap<User, UserDto>().ReverseMap();
            this.CreateMap<UserClaim, UserClaimDto>().Ignore(p => p.User).ReverseMap();
            this.CreateMap<UserLogin, UserLoginDto>().Ignore(p => p.User).ReverseMap();
            this.CreateMap<UserRole, UserRoleDto>().Ignore(p => p.User).Ignore(p => p.Role).ReverseMap();
            this.CreateMap<UserToken, UserTokenDto>().Ignore(p => p.User).ReverseMap();
            this.CreateMissingTypeMaps = false;
        }
    }
}
