using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Filters;
using SnappedChallengeApi._Corelib.Extensions;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnappedChallengeApi.Filters
{
    /// <summary>
    /// Custom auth header swagger doc operation filter manupulation
    /// </summary>
    public class AuthorizationHeaderFilter : IOperationFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(Operation operation, OperationFilterContext context)
        {
            IEnumerable<ClientAuthorizeAttribute> attrs = context.GetAllAttrs<ClientAuthorizeAttribute>();
            if (!attrs.Any()) return;
            //
            if (operation.Parameters.IsNullOrEmpty())
                operation.Parameters = new List<IParameter>();
            //
            operation.Parameters.Add(new BodyParameter()
            {
                Required = true,
                In = "header",
                Name = ClientAuthorizeAttribute.TokenHeaderName,
                Description = "Authorization Header",
                Schema = new Schema()
                {
                    Type = "string"
                }
            });
        }
    }
    /// <summary>
    /// Attribute Class For Swagger Tag Manipulation keeping together required so it is defined in same class file
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ClientAuthorizeAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Auth Header Name
        /// </summary>
        internal const string TokenHeaderName = "Authorization";
        /// <summary>
        /// Auth Header Prefix Text
        /// </summary>
        internal const string SchemaHeaderPrefix = "Bearer ";

        /// <summary>
        /// Check Method For Auth Token Dummy Check is done for exercise
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Headers.Keys.Contains(TokenHeaderName))
                throw new Exception("Authorization Token Not Exists, Unauthorized!");

            //usually a token provider is being used for token validation but for this exercise only existance is enough for us.
            base.OnActionExecuting(context);
        }
    }
}
