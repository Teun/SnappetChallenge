using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SnappetWorkApp.Services;
using SnappetWorkApp.Repositories;

namespace SnappetWorkApp {
    public class Startup{

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<WorkDataContext>(options => options.UseInMemoryDatabase());

            services.AddTransient<IViewModelFactory, ViewModelFactory>();
            services.AddTransient<IStudentsRepository, StudentsRepository>();
        }

        public void Configure(IApplicationBuilder app){

            app.UseMvcWithDefaultRoute();

            app.Run(context => {
                return context.Response.WriteAsync("Hello world");
            });
        }
    }
}