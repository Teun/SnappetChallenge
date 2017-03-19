using System.Net.Http.Headers;
using System.Web.Http;

namespace Dashboard
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            config.Routes.MapHttpRoute(
                name: "Report",
                routeTemplate: "api/{controller}/{reportName}",
                defaults: new { });
        }
    }
}
