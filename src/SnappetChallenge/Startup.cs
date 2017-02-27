using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SnappetChallenge.Business;
using SnappetChallenge.Models;

namespace SnappetChallenge
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration("StudyProfile"));
            });

            services.AddSingleton(config.CreateMapper());
            services.AddDbContext<StudyContext>(opt=>opt.UseInMemoryDatabase());
            services.AddScoped<ReportManager>();
            services.AddMvc();
        }

        public async void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            var context = app.ApplicationServices.GetService<StudyContext>();
            await context.SyncWithData();
        }
    }
}
