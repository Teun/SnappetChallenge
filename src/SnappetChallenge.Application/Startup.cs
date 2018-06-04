using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SnappetChallenge.Application.Requests;
using SnappetChallenge.Core.Repositories.Contracts;
using SnappetChallenge.CrossCutting.Settings;
using SnappetChallenge.Infrastructure.AutoMapper;
using SnappetChallenge.Infrastructure.Repositories;

namespace SnappetChallenge.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddMemoryCache();
            services.AddAutoMapper(typeof(EntitiesToDTOProfile).Assembly);
            services.AddMediatR();

            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            services.AddScoped<IWorkRepository, WorkRepository>();

            services.AddMvc()
                    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<GetWorksForDateRequest>());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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
        }
    }
}
