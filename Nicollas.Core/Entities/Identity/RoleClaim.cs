//-----------------------------------------------------------------------
// <copyright file="RoleClaim.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas.Core.Entities.Identity
{
    using System;
    using System.Diagnostics;
    using System.Security.Claims;

    /// <summary>
    /// The Role Claim Entity
    /// </summary>
    [DebuggerDisplay("RoleClaim: {ClaimType} => {ClaimValue}")]
    public class RoleClaim : BaseEntity<Guid>, IEntity<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleClaim" /> class.
        /// </summary>
        public RoleClaim()
        {
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleClaim" /> class.
        /// </summary>
        /// <param name="type">The claim type</param>
        /// <param name="value">The claim value</param>
        public RoleClaim(ClaimDefinition.Type type, ClaimDefinition.Value value)
        {
            this.Id = Guid.NewGuid();
            this.ClaimType = type.ToString();
            this.ClaimValue = value.ToString();
        }

        /// <summary>
        /// Gets or sets the of the primary key of the role associated with this claim.
        /// </summary>
        public virtual Guid RoleId { get; set; }

        /// <summary>
        ///  Gets or sets the role
        /// </summary>
        //[Newtonsoft.Json.JsonIgnore]
        public virtual Role Role { get; set; }

        /// <summary>
        /// Gets or sets the claim type for this claim.
        /// </summary>
        public virtual string ClaimType { get; set; }

        /// <summary>
        /// Gets or sets the claim value for this claim.
        /// </summary>
        public virtual string ClaimValue { get; set; }

        /// <summary>
        /// Obtain a Claim <see cref="Claim"/>
        /// </summary>
        /// <returns>A Claim</returns>
        public virtual Claim ToClaim()
        {
            return new Claim(this.ClaimType, this.ClaimValue);
        }

        /// <summary>
        /// Clone a Claim <see cref="Claim"/>
        /// </summary>
        /// <param name="other">The source claim</param>
        public virtual void InitializeFromClaim(Claim other)
        {
            if (other.IsValidClaim())
            {
                this.ClaimType = other?.Type;
                this.ClaimValue = other?.Value;
            }
        }
    }
}
