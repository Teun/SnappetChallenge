//-----------------------------------------------------------------------
// <copyright file="UserTokenConfiguration.cs" company="Soulft">
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
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserTokenConfiguration" /> class
        /// </summary>
        /// <param name="builder">The type builder</param>
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.HasKey(rc => rc.Id);
            builder.ToTable("UserTokens");
        }
    }
}
