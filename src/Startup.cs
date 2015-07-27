using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Xml;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Runtime;

using NuGet;

using SnappetChallenge.Data;
using SnappetChallenge.Data.Contracts;
using SnappetChallenge.Services;
using SnappetChallenge.Services.Contracts;

namespace SnappetChallenge
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder(appEnv.ApplicationBasePath)
                .AddIniFile("config.ini");

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; set; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.Configure<Settings>(Configuration);

            // By default the response type of ASP.NET Web API is JSON, 
            // however if the client requests application/xml that is what will be returned. 
            // The configuration below forces JSON results for all requests.
            services.Configure<MvcOptions>(options =>
                options.OutputFormatters.RemoveAll(formatter =>
                    formatter is XmlDataContractSerializerOutputFormatter));

            // Register data access layer dependencies.
            services.AddSingleton<IMongoDatabaseFactory, MongoDatabaseFactory>();
            services.AddSingleton<ISubmittedAnswersRepository, SubmittedAnswersRepository>();

            // Register application service(s).
            services.AddScoped<IClassResults, ClassResults>();
        }

        /// <remarks>
        /// Configure is called after ConfigureServices is called.
        /// </remarks>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Configure the HTTP request pipeline.
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
