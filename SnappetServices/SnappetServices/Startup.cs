using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SnappetServices.Repositories;
using SnappetServices.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace SnappetServices
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAutoMapper(ConfigureMapper, typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Snappet API",
                    Description = "Snappet API for demonstration",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Nishant Agrawal", Email = "nishantkagrawal@gmail.com", Url = "www.github.com/nishantkagrawal" }
                });
            });

            services.AddScoped<IResultsRepository, ResultsRepository>();
            services.AddScoped<IResultsServices, ResultsServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseCors(options =>
            {
                options.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Snappet API V1");
            });
        }

        public static void ConfigureMapper(IMapperConfigurationExpression config)
        {
            config.AddProfile(new AutoMapperDefaultProfile());
        }
    }
}
