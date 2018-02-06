using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Snappet.Assignment.Data.Context;
using Microsoft.EntityFrameworkCore;
using Snappet.Assignment.Entities.Mapping;
using Snappet.Assignment.Entities.Interfaces;
using Snappet.Assignment.Business.Interfaces;
using Snappet.Assignment.Business.UnitOfWork;

namespace Snappet.Assignment.WebApp
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
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            // Add framework services.
            services.AddDbContext<SchoolDbContext>(options =>
                options.UseSqlServer(connectionString, x => x.MigrationsAssembly("Snappet.Assignment.WebApp")));

            services.AddMvc()
                    .AddJsonOptions(
                    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSingleton<IMapper, Mapper>();
            services.AddScoped<IUnitOfWork>(c => new UnitOfWork(connectionString));
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
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

                routes.MapSpaFallbackRoute(
                  name: "spa-fallback",
                  defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
