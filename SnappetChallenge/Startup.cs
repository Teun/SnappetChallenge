using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlashMapper;
using LightInject;
using LightInject.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SnappetChallenge.Core;
using SnappetChallenge.Data;
using SnappetChallenge.Infrastructure;

namespace SnappetChallenge
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var containerOptions = new ContainerOptions { EnablePropertyInjection = false };
            var serviceContainer = new ServiceContainer(containerOptions);
            //Register your own services within LightInject
            serviceContainer.RegisterModule(new InfrastructureModule())
                .RegisterModule(new DataModule())
                .RegisterModule(new CoreModule())
                .RegisterModule(new WebModule());

            var builders = serviceContainer.GetInstance<IEnumerable<IFlashMapperBuilder>>();
            serviceContainer.GetInstance<IAppInitializer>()
                .Start();

            services.AddMvc()
                .AddControllersAsServices();
            //Build and return the Service Provider
           return serviceContainer.CreateServiceProvider(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
