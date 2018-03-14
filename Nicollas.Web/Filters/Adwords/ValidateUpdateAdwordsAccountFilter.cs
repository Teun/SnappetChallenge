// <copyright file="ValidateUpdateAdwordsAccountFilter.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>

namespace Nicollas.Ng.Filters.Identity
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Primitives;

    /// <summary>
    /// Validate the updateAdwordsAccountFilter route with an rash code to avoid spams
    /// </summary>
    public class ValidateUpdateAdwordsAccountFilter : Attribute, IFilterFactory
    {
        /// <inheritdoc/>
        public bool IsReusable => true;

        /// <inheritdoc/>
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return new InternalValidateUpdateAdwordsAccountFilter((IConfigurationRoot)serviceProvider.GetService(typeof(IConfiguration)));
        }

        private class InternalValidateUpdateAdwordsAccountFilter : ActionFilterAttribute
        {
            private IConfigurationRoot configuration;

            public InternalValidateUpdateAdwordsAccountFilter(IConfigurationRoot configuration)
            {
                this.configuration = configuration;
            }

            /// <summary>
            /// Event throw before call the api controller
            /// </summary>
            /// <param name="context"><see cref="ActionExecutingContext"/></param>
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                context.HttpContext.Request.Headers.TryGetValue("Dashboard-Token", out StringValues token);
                var rash = this.configuration.GetSection("Dashboard-Token").Value;
                if (token.Count == 0 || token[0] != rash)
                {
                    context.Result = new BadRequestResult();
                }
            }
        }
    }
}
