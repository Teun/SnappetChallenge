using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SnappedChallengeApi.DAL;
using SnappedChallengeApi.Filters;
using SnappedChallengeApi.Models.Commons;
using SnappedChallengeApi.Services.Implementations;
using SnappedChallengeApi.Services.Interfaces;
using SnappedChallengeApi.UIServices.Implementations;
using SnappedChallengeApi.UIServices.Interfaces;
using Swashbuckle.AspNetCore.Swagger;

namespace SnappedChallengeApi
{
    /// <summary>
    /// Startup class for service 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Service Name For Swagger Docs
        /// </summary>
        public const string ServiceName = "Snapped Challenge API";
        /// <summary>
        /// Service Title For Swagger Docs
        /// </summary>
        public const string ServiceTitle = "My snapped challange, let's see what i can do...";
        /// <summary>
        /// Service Settings Instance for launch configs
        /// </summary>
        public ServiceSettings ServiceSettings = null;
        /// <summary>
        /// Service api version
        /// </summary>
        public const string ApiVersion = "v1";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //mvc registeration
            services.AddMvc();

            ServiceSettings.InitializeSettings(Configuration); 
            

            //Swagger registeration
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(ApiVersion, new Info
                {
                    Version = ApiVersion,
                    Title = ServiceName,
                    Description = ServiceTitle,
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Emre Ergüden",
                        Email = "emreerguden@gmail.com"
                    },
                    License = new License()
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.OperationFilter<AuthorizationHeaderFilter>();
            });

            //controllers' services
            services.AddSingleton<IClassworkService>(new ClassworkService());
            services.AddSingleton<ICommonService>(new CommonService());

            //Simualation of client services that consumes apis
            services.AddSingleton<IClassworkClientService>(new ClassworkClientService());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            #region Standard Registerations
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            #endregion

            #region Swagger Initialization
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", ServiceName);
            });
            #endregion
        }
    }
}
