// <copyright file="LookupNormalizer.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>

namespace Nicollas.Identity
{
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// The LookupNormalize
    /// </summary>
    public class LookupNormalizer : ILookupNormalizer
    {
        /// <inheritdoc/>
        public string Normalize(string key)
        {
            return key?.ToUpperInvariant();
        }
    }
}
