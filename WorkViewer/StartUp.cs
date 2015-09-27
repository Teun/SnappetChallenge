using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Http.Routing;

namespace WorkViewer
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration httpConfiguration = new HttpConfiguration();
            httpConfiguration.Routes.MapHttpRoute("DefaultRoute", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            appBuilder.UseWebApi(httpConfiguration);
            appBuilder.UseHttpGetResource();
            appBuilder.UseNotFound();
        }

        
    }
}
