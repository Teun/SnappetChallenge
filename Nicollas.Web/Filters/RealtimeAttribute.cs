// <copyright file="RealtimeAttribute.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>

namespace Nicollas.Ng.Filters
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Nicollas.Dto.Realtime;
    using Nicollas.Ng.Middlewares;

    /// <summary>
    /// Specifies that the class or method that this attribute is applied to will have the response broadcasted from connecteds websockets
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class RealtimeAttribute : ResultFilterAttribute
    {
        private ActionNeeded actionNeeded;
        private string reducer;
        private string type;
        private string callback;

        /// <summary>
        /// Initializes a new instance of the <see cref="RealtimeAttribute"/> class.
        /// </summary>
        /// <param name="actionNeeded">The action that the Frontend need to take</param>
        /// <param name="reducer">the reducer</param>
        /// <param name="type">type of action on reducer</param>
        /// <param name="callback">The callback action when needed</param>
        public RealtimeAttribute(ActionNeeded actionNeeded = ActionNeeded.DoCallback, string reducer = null, string type = null, string callback = null)
        {
            this.actionNeeded = actionNeeded;
            this.reducer = reducer;
            this.type = type;
            this.callback = callback;
        }

        /// <inheritdoc/>
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            int statusCode;

            RealtimeDto response = new RealtimeDto { ActionNeeded = this.actionNeeded };

            if (context.Result is StatusCodeResult)
            {
                statusCode = (context.Result as StatusCodeResult).StatusCode;
            }
            else if (context.Result is ObjectResult)
            {
                statusCode = (context.Result as ObjectResult).StatusCode.Value;
                response.Result = (context.Result as ObjectResult).Value;
            }
            else
            {
                return; // Not aply for this attribute
            }

            if (statusCode < 200 || statusCode > 299)
            {
                return; // Only Success messages apply
            }

            context.ActionDescriptor.RouteValues.TryGetValue("controller", out var controllerName);
            context.ActionDescriptor.RouteValues.TryGetValue("action", out var actionMethod);
            context.HttpContext.Request.Headers.TryGetValue("realtime-token", out var realtimeToken);

            response.Callback = this.callback;
            response.Type = this.type;
            response.Reducer = this.reducer ?? controllerName;
            response.ActionName = actionMethod;
            response.Method = context.HttpContext.Request.Method;

            var awaiter = WebSocketMiddleware.BroadcastMessage(response, realtimeToken);
        }
    }
}
