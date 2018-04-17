//-----------------------------------------------------------------------
// <copyright file="RoleConfiguration.cs" company="Soulft">
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
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleConfiguration" /> class
        /// </summary>
        /// <param name="builder">The type builder</param>
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);

            // HasIndex(r => r.NormalizedName).HasName("RoleNameIndex");
            builder.ToTable("Roles");
            builder.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

            builder.Property(u => u.Name).HasMaxLength(256);
            builder.Property(u => u.NormalizedName).HasMaxLength(256);

            builder.HasMany(r => r.Users).WithOne().IsRequired().HasForeignKey(ur => ur.RoleId);
            builder.HasMany(r => r.Claims).WithOne().IsRequired().HasForeignKey(rc => rc.RoleId);
        }
    }
}
