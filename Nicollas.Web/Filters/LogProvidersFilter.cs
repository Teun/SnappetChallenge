// <copyright file="LogProvidersFilter.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>

namespace Nicollas.Ng.Filters
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Nicollas.Ng.Extensions;

    /// <summary>
    /// Specifies that the class or method that this attribute is applied to will have the request and response logged
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class LogProvidersFilter : ActionFilterAttribute
    {
        /// <summary>
        /// Event throw before and after call the controller
        /// </summary>
        /// <param name="context"><see cref="ActionExecutingContext"/></param>
        /// <param name="next">The context to execute</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var path = context.HttpContext.Request.Path.Value;
            var method = context.HttpContext.Request.Method;
            var requestParams = context.ActionArguments.ToJsonString();

            var result = (await next.Invoke()).Result.ToJsonString();

            // TODO: Log on DocumentDB

            // Access each paramether
            // foreach (var param in context.ActionDescriptor.Parameters)
            // {
            //     var tmp = context.ActionArguments[param.Name];
            // }
        }
    }
}