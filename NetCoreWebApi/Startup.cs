using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace WorkDataService {
    public class Startup{

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<WorkDataContext>(options => options.UseInMemoryDatabase());

            services.AddTransient<IStudentFactory, StudentFactory>();
        }

        public void Configure(IApplicationBuilder app){

            app.UseMvcWithDefaultRoute();

            app.Run(context => {
                return context.Response.WriteAsync("Hello world");
            });
        }
    }
}