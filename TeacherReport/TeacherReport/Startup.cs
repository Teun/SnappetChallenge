using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using DataRepositories.Implementations;
using DataRepositories.Interfaces;

namespace TeacherReport
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
            services.AddMvc();

            //The file loader can be a singleton. It has no state whatsoever.
            services.AddSingleton<IAnswerDataJsonFileLoader, AnswerDataJsonFileLoader>();

            //We can share the answer DB among all requests, so it can be a singleton too
            services.AddSingleton<IAnswerDB, AnswerDB>(serviceProvider =>
                new AnswerDB(serviceProvider.GetService<IAnswerDataJsonFileLoader>(), Constants.DataFiles.AnswersDataFile));

            //This doesn't currently have state, but it may in the future. So I'm making this 
            //a request-scoped instance
            services.AddScoped<IAnswerRepository, AnswerRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
