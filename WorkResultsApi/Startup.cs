using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WorkResultsApi.Infrastructure;
using WorkResultsApi.Models;

namespace WorkResultsApi
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WorkResultsApi", Version = "v1" });
            });

            services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("InMemoryDatabase"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WorkResultsApi v1"));
            }

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });            

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                PopulateInMemoryDatabase(context);
            }
        }

        private static void PopulateInMemoryDatabase(ApplicationDbContext context)
        {
            List<StudentWorkItem> studentWorkItems;
            using (var streamReader = new StreamReader("./Data/work.json"))
            {
                var studentWorkItemsJson = streamReader.ReadToEnd();
                studentWorkItems = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<StudentWorkItem>>(studentWorkItemsJson).ToList();
            }

            context.StudentWorkItems.AddRange(studentWorkItems);
            context.SaveChanges();
        }
    }
}
