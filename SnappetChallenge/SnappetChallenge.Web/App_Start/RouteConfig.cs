using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SnappetChallenge.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // add API routing
            routes.MapRoute(
                name: "API",
                url: "api/{controller}/{action}"
            );

            // regular MVC routing
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Overview", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
