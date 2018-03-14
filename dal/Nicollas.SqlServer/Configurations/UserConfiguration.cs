//-----------------------------------------------------------------------
// <copyright file="UserConfiguration.cs" company="Soulft">
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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserConfiguration" /> class
        /// </summary>
        /// <param name="builder">The type builder</param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            // HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
            // HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");
            builder.ToTable("Users");
            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            builder.Property(u => u.UserName).HasMaxLength(256);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(256);
            builder.HasMany(u => u.Claims).WithOne().IsRequired().HasForeignKey(uc => uc.UserId);

            // HasMany(u => u.Logins).WithOne().HasForeignKey(ul => ul.UserId).IsRequired();
            builder.HasMany(u => u.Roles).WithOne().IsRequired().HasForeignKey(ur => ur.UserId);
        }
    }
}
