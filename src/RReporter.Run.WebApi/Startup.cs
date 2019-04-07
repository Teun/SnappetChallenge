using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RReporter.Application.ReportWorkSummary;
using RReporter.Application.ReportWorkSummary.Depends;
using RReporter.Application.StoreWorkEvent;
using RReporter.Application.StoreWorkEvent.Depends;
using RReporter.Framework;

namespace RReporter.Run.WebApi
{
    public class Startup
    {
        public Startup (IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services)
        {
            services.AddCors (options =>
            {
                options.AddPolicy ("CorsPolicy",
                    builder => builder.WithOrigins ("http://localhost:4200")
                    .AllowAnyMethod ()
                    .AllowAnyHeader ()
                    .AllowCredentials ());
            });
            services.AddSignalR ();
            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_1);
        }

        // ConfigureContainer is where you can register things directly
        // with Autofac. 
        public void ConfigureContainer (ContainerBuilder builder)
        {
            builder.RegisterType<MemoryPupilsStorage> ()
                .As<IGetPupilsInClass> ()
                .SingleInstance ();

            builder.RegisterType<MemoryWorkEventStorage> ()
                .As<IStoreWorkEvents> ()
                .As<IGetDayWorkEventsForPupil> ()
                .SingleInstance ();

            builder.RegisterType<OffsetTimeProvider> ()
                .As<ITimeProvider> ()
                .SingleInstance ();

            builder.RegisterType<WorkEventHandler> ()
                .As<IWorkEventHandler> ()
                .InstancePerDependency ();

            builder.RegisterType<WorkSummaryQueries> ()
                .As<IWorkSummaryQueries> ()
                .InstancePerDependency ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole (this.Configuration.GetSection ("Logging"));
            loggerFactory.AddDebug ();

            if (env.IsDevelopment ())
            {
                app.UseDeveloperExceptionPage ();
            }
            else
            {
                app.UseHsts ();
            }

            app.UseHttpsRedirection ();
            app.UseCors ("CorsPolicy");

            // map routes
            app.UseSignalR (routes =>
            {
                routes.MapHub<WorkSummaryHub> ("/hub");
            });
            app.UseMvc (routes =>
            {
                routes.MapRoute ("default", "api/{classId}",
                    new
                    {
                        controller = "WorkSummary",
                            action = "Get"
                    });
            });
        }
    }
}