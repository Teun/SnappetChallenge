// <copyright file="SessionRequirementFilter.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>

namespace Nicollas.Ng.Filters.Adwords
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    /// <summary>
    /// Filter to act with session requests
    /// </summary>
    public class SessionRequirementFilter : IAsyncActionFilter
    {
        private readonly string propertyName;
        private readonly object value;

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionRequirementFilter"/> class.
        /// </summary>
        /// <param name="propertyName">Name of one <see cref="SessionFacility"/> property</param>
        /// <param name="expectedValue">The expected value of the property</param>
        public SessionRequirementFilter(string propertyName, object expectedValue)
        {
            this.propertyName = propertyName;
            this.value = expectedValue;
        }

        /// <summary>
        /// Intercept the executing context to check if have the required values on session
        /// </summary>
        /// <param name="context">the ActionExecutingContext</param>
        /// <param name="next">The next context</param>
        /// <returns>A task</returns>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var facility = new SessionFacility(new HttpContextAccessor { HttpContext = context.HttpContext });

            bool result = typeof(SessionFacility).GetProperty(this.propertyName).GetValue(facility).Equals(this.value);

            if (!result)
            {
                context.Result = new UnauthorizedResult();
            }
            else
            {
                await next();
            }
        }
    }
}
