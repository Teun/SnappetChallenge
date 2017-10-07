using Snappet.Challenge.Filters;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;

namespace Snappet.Challenge
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var corsPolicy = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(corsPolicy);
            // Web API configuration and services
            config.Services.Replace(typeof(IExceptionHandler), new CustomExceptionHandler());
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
