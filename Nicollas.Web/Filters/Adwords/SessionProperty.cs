// <copyright file="SessionProperty.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>

namespace Nicollas.Ng.Filters.Adwords
{
    /// <summary>
    /// Contain all claim needed
    /// </summary>
    public static class SessionProperty
    {
        /// <summary>
        /// Indicate the needed to check the Adwords Authorization
        /// </summary>
        public const string AdwordsProviderAuthStatus = "AdwordsProviderAuthStatus";

        /// <summary>
        /// Indicate the needed to check the Adwords oauth Authorization is initialized
        /// </summary>
        public const string AdwordsProviderHavePendingAuthRequest = "AdwordsProviderHavePendingAuthRequest";
    }
}
