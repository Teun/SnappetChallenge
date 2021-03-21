using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Snappet.API.Extensions;
using Snappet.Logic.Logger;

namespace Snappet.API
{
    public class Startup
    {
        private const string ConnectionStringName = "cns";

        /// <summary>
        /// Database connection string
        /// </summary>
        private string ConnectionString
        {
            get
            {
                var rst = Configuration.GetConnectionString(ConnectionStringName);
                return (rst);
            }
        }

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Add logger service (NLog)
            services.AddSingleton<ILoggerManager, LoggerManager>();

            //Add configuration to the service pool
            services.AddSingleton<IConfiguration>(Configuration);

            //Add default mapper
            services.AddMapper();

            //Add default ORM
            services.AddORM(ConnectionString);

            //Set swagger document
            services.AddSwaggerDocument();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Use my custom global error handling as a middleware
            app.UseMiddleware<Middlewares.ExceptionMiddleware>();

            //Swagger settings
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
