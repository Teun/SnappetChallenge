// <copyright file="AntiForgeryToken.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>
namespace Nicollas.Ng.Filters
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    /// <summary>
    /// Anti Forgery Token Validator
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AntiForgeryToken : ActionFilterAttribute
    {
        /// <summary>
        /// Event throw before call the api controller
        /// </summary>
        /// <param name="context"><see cref="ActionExecutingContext"/></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Request.Cookies.TryGetValue("XSRF-TOKEN", out string token);

            if (token == null || token != context.HttpContext.Request.Headers["X-XSRF-TOKEN"])
            {
                context.Result = new BadRequestResult();
            }
        }
    }
}
