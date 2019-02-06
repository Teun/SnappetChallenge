using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Snappet.ClassInsights.Business.Extensions;
using Snappet.ClassInsights.Model.Configurations;
using Snappet.ClassInsights.Orm;
using Snappet.ClassInsights.Orm.Extensions;
using Swashbuckle.AspNetCore.Swagger;

namespace Snappet.ClassInsights.WebApi
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
            services.AddLogging();
            services.Configure<DataSeederOptions>(Configuration.GetSection(nameof(DataSeederOptions)));
            services.AddClassInsightsOrmWithSqlite(Configuration.GetConnectionString("DefaultConnection"));
            services.AddClassInsightsServices();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0.0", new Info { Title = "Snappet Class Insights Api", Version = "v1.0.0" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<InsightsContext>();

                context.Database.Migrate();
                if(context.SubmittedAnswers.Count()==0)
                {
                    var seeder = serviceScope.ServiceProvider.GetService<IDataSeeder>();
                    seeder.SeedSubmittedAnswersAsync(Configuration.GetConnectionString("DefaultConnection")).Wait();
                }

            }
            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0.0/swagger.json", "Snappet Class Insights Api V1.0.0");
                c.RoutePrefix = string.Empty;
            });
            app.UseCors(builder => builder.AllowAnyOrigin());
            app.UseMvc();
        }
    }
}
