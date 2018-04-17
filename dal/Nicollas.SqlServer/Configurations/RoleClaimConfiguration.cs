//-----------------------------------------------------------------------
// <copyright file="RoleClaimConfiguration.cs" company="Soulft">
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
    /// Class for all the entities configuration.
    /// </summary>
    public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleClaimConfiguration" /> class
        /// </summary>
        /// <param name="builder">The type builder</param>
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.HasKey(rc => rc.Id);
            builder.ToTable("RoleClaims");
        }
    }
}
