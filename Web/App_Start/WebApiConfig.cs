using System.Web.Http;

namespace Web
{
	public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			config.MapHttpAttributeRoutes();
        }
    }
}
