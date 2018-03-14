//-----------------------------------------------------------------------
// <copyright file="UserRoleConfiguration.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas.SqlServer.Configurations
{
    using Core.Entities.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// <para> Class for all the entities configuration. </para>
    /// </summary>
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRoleConfiguration" /> class
        /// </summary>
        /// <param name="builder">The type builder</param>
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(r => new { r.UserId, r.RoleId });
            builder.ToTable("UserRoles");
        }
    }
}
