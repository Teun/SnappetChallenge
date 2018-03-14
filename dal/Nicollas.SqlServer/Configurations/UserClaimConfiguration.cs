//-----------------------------------------------------------------------
// <copyright file="UserClaimConfiguration.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Nicollas.SqlServer.Configurations
{
    using Core.Entities.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// <para> Class for all the entities configuration. </para>
    /// </summary>
    public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserClaimConfiguration" /> class
        /// </summary>
        /// <param name="builder">The type builder</param>
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.HasKey(rc => rc.Id);
            builder.ToTable("UserClaims");
        }
    }
}
