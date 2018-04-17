// <copyright file="ValidateSignUpFilter.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>
namespace Nicollas.Ng.Filters.Identity
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    /// <summary>
    /// SingUp Validator
    /// </summary>
    public class ValidateSignUpFilter : ActionFilterAttribute
    {
        /// <summary>
        /// Event throw before call the api controller
        /// </summary>
        /// <param name="context"><see cref="ActionExecutingContext"/></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
