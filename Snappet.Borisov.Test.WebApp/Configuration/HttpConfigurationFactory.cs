using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Newtonsoft.Json.Serialization;

namespace Snappet.Borisov.Test.WebApp.Configuration
{
    public class HttpConfigurationFactory
    {
        private readonly ILifetimeScope _container;

        public HttpConfigurationFactory(ILifetimeScope container)
        {
            _container = container;
        }

        public HttpConfiguration Create()
        {
            var config = new HttpConfiguration
            {
                DependencyResolver = new AutofacWebApiDependencyResolver(_container)
            };

            // Some strange magic from autofac. No use of container builder in this method.
            new ContainerBuilder().RegisterHttpRequestMessage(config);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional }
                );

            var jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            jsonFormatter.MediaTypeMappings.Add(new UriPathExtensionMapping("json", "application/json"));
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonFormatter.UseDataContractJsonSerializer = false;

            return config;
        }
    }
}