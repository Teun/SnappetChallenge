using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Snappet.API.Extensions;
using Snappet.Logic.Logger;

namespace Snappet.API
{
    public class Startup
    {
        private const string ConnectionStringName = "cns";

        #region properties
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
        #endregion


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Add logger service (NLog)
            services.AddSingleton<ILoggerManager, LoggerManager>();

            services.ConfigureCors();

            //Add configuration to the service pool
            services.AddSingleton<IConfiguration>(Configuration);

            //Add Authuntication service based on JWT
            services.AddJWT(Configuration);

            //Add default mapper
            services.AddMapper();

            //Add default ORM
            services.AddORM(ConnectionString);

            //Set swagger settings
            services.setSwaggerSettings();

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
