// <copyright file="SessionRequirementAttribute.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>

namespace Nicollas.Ng.Filters.Adwords
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// SessionRequirementAttribute class
    /// </summary>
    public class SessionRequirementAttribute : TypeFilterAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionRequirementAttribute"/> class.
        /// </summary>
        /// <param name="propertyName">Name of one <see cref="SessionFacility"/> property</param>
        /// <param name="expectedValue">The expected value of the property</param>
        public SessionRequirementAttribute(string propertyName, object expectedValue)
            : base(typeof(SessionRequirementFilter))
        {
            this.Arguments = new object[] { propertyName, expectedValue };
        }
    }
}
