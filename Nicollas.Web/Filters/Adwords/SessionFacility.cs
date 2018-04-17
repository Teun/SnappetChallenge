// <copyright file="SessionFacility.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>

namespace Nicollas.Ng.Filters.Adwords
{
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Class to help with Section
    /// </summary>
    public class SessionFacility
    {
        private static string adwordsConfigAuthStatus = "AdwordsConfigAuthStatus";
        private IHttpContextAccessor contextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionFacility"/> class.
        /// </summary>
        /// <param name="contextAccessor">The context Accessor</param>
        public SessionFacility(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        /// <summary>
        /// Gets a value indicating whether the adwordsProvider are Authenticated
        /// </summary>
        public bool AdwordsProviderAuthStatus
        {
            get
            {
                return bool.Parse(this.Context.Session.GetString(adwordsConfigAuthStatus) ?? "false");
            }

            private set
            {
                this.Context.Session.SetString(adwordsConfigAuthStatus, value.ToString());
            }
        }

        private HttpContext Context
        {
            get { return this.contextAccessor.HttpContext; }
        }
    }
}
