using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Extensions;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using Snappet.Test.TopStudents.Web;
using Swashbuckle.Application;

[assembly: OwinStartup(typeof(Startup))]
namespace Snappet.Test.TopStudents.Web
{
    

    internal partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);

            var httpConfiguration = new HttpConfiguration();

            // Configure Swagger UI
            httpConfiguration
                .EnableSwagger(c => c.SingleApiVersion("v1", "A title for your API"))
                .EnableSwaggerUi();

            // Configure Web API Routes:
            // - Enable Attribute Mapping
            httpConfiguration.MapHttpAttributeRoutes();

            ConfigureAutofac(httpConfiguration);

            // Camel case json serialization
            JsonSerializerSettings jsonSettings = httpConfiguration.Formatters.JsonFormatter.SerializerSettings;
            jsonSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            httpConfiguration.Formatters.Remove(httpConfiguration.Formatters.XmlFormatter);

            app.UseWebApi(httpConfiguration);

            // Make ./public the default root of the static files in our Web Application.
            app.UseFileServer(new FileServerOptions
            {
                RequestPath = new PathString(string.Empty),
                FileSystem = new PhysicalFileSystem("./public"),
                EnableDirectoryBrowsing = true,
            });

            app.UseStageMarker(PipelineStage.MapHandler);
        }
    }
}
