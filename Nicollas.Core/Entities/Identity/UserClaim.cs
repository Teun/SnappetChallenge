//-----------------------------------------------------------------------
// <copyright file="UserClaim.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>
// <author></author>
//-----------------------------------------------------------------------
namespace Nicollas.Core.Entities.Identity
{
    using System;
    using System.Security.Claims;

    /// <summary>
    /// The User Claim Entity
    /// </summary>
    public class UserClaim : BaseEntity<Guid>, IEntity<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserClaim" /> class.
        /// </summary>
        public UserClaim()
        {
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets the primary key of the user associated with this claim.
        /// </summary>
        public virtual Guid UserId { get; set; }

        /// <summary>
        ///  Gets or sets the user
        /// </summary>
        //[Newtonsoft.Json.JsonIgnore]
        public virtual User User { get; set; }

        /// <summary>
        /// Gets or sets the claim type for this claim.
        /// </summary>
        public virtual string ClaimType { get; set; }

        /// <summary>
        /// Gets or sets the claim value for this claim.
        /// </summary>
        public virtual string ClaimValue { get; set; }

        /// <summary>
        /// Converts the entity into a Claim instance.
        /// </summary>
        /// <returns>A Claim</returns>
        public virtual Claim ToClaim()
        {
            return new Claim(this.ClaimType, this.ClaimValue);
        }

        /// <summary>
        /// Reads the type and value from the Claim.
        /// </summary>
        /// <param name="claim">The source Claim</param>
        public virtual void InitializeFromClaim(Claim claim)
        {
            this.ClaimType = claim.Type;
            this.ClaimValue = claim.Value;
        }
    }
}
