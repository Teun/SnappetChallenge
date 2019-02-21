using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using StudentsAPI.WebApi.Configuration;
using StudentsAPI.WebApi.Context;
using StudentsAPI.WebApi.Services;

namespace StudentsAPI.WebApi
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
            services.Configure<MongoDbConfiguration>(Configuration.GetSection("MongoDb"));

            services.AddTransient<IWorkItemRepository, WorkItemRepository>();
            services.AddTransient<IWorkItemService, WorkItemService>();
            services.AddTransient<IWorkItemContext, WorkItemContext>();
            services.AddMvc();

            //Configure swagger generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Students API", Version = "v1" });
            });

        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Students API V1");
            });

            app.UseMvc();
        }
    }
}
