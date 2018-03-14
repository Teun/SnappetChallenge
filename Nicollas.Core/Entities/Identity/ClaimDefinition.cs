// <copyright file="ClaimDefinition.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>

namespace Nicollas.Core.Entities.Identity
{
    using System;
    using System.Security.Claims;

    /// <summary>
    /// This class is responsable to validate Claims type and values
    /// </summary>
    public static class ClaimDefinition
    {
        /// <summary>
        /// The Type define types of clains allowed on the system
        /// </summary>
        public enum Type
        {
            /// <summary>
            /// The User Type
            /// </summary>
            User,

            /// <summary>
            /// The Product type
            /// </summary>
            Product,

            /// <summary>
            /// The Table type
            /// </summary>
            Table,

            /// <summary>
            /// The Order type
            /// </summary>
            Order,

            /// <summary>
            /// The Bill type
            /// </summary>
            Bill,

            /// <summary>
            /// The Register type
            /// </summary>
            Register
        }

        /// <summary>
        /// The values define values allowed on each claim type
        /// </summary>
        public enum Value
        {
            /// <summary>
            /// Define that an claim type is allowed
            /// </summary>
            Allow,

            /// <summary>
            /// Define that an claim type is denied
            /// </summary>
            Deny,
        }

        /// <summary>
        /// Determine if the claim is valid
        /// </summary>
        /// <param name="claim">The clain to verify</param>
        /// <returns>True if is an valid claim</returns>
        public static bool IsValidClaim(this Claim claim)
        {
            return Enum.IsDefined(typeof(ClaimDefinition.Type), claim.Type) && Enum.IsDefined(typeof(ClaimDefinition.Value), claim.Value);
        }
    }
}
