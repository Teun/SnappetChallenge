using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Snappet.Reporting.Application;
using Snappet.Reporting.Storage.Sql;

namespace Snappet.Reporting.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ReportingDbContext>(opt => opt.UseInMemoryDatabase());
            // Add framework services.
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddCors(options => options.AddPolicy("AllowAnyOrigin", builder => builder.AllowAnyOrigin()));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ReportingDbContext reportingDbContext)
        {
            if(env.IsDevelopment())
            {
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowAnyOrigin");
            app.UseMvcWithDefaultRoute();
            DbInitializer.Initialize(reportingDbContext, loggerFactory);
        }
    }
}
