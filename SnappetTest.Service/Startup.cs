using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SnappetTest.Data.Attributes;
using SnappetTest.Data.Repositories;
using SnappetTest.Data.Abstract;
using SnappetTest.Service.ViewModels.Mappings;
using SnappetTest.Service.Infrastructure.Abstract;
using SnappetTest.Service.Infrastructure.Implementation;



namespace SnappetTest.Service
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.Configure<MongoAttributes>(options => Configuration.GetSection("MongoAttributes").Bind(options));
            services.AddSingleton<ISnappetTestRepository, SnappetTestRepository>();
            services.AddSingleton<ISnappetFactory, SnappetFactory>();
            services.AddScoped<GetResultOnTimeStamp>();
           

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.ConfigureSubmiitedAnswerMapping();
            });

            services.AddSingleton(x => config.CreateMapper());
            services.AddSingleton<IFetchAnswerCountProvider, FetchAnswerCountProvider>();
            services.AddSingleton<IFetchCorrectAnswerCountProvider, FetchCorrectAnswerCountProvider>();
            services.AddSingleton<IFetchProgressProvider, FetchProgressProvider>();
            services.AddSingleton<IFetchRequestedDateProvider, FetchRequestedDate>();
            services.AddSingleton<IFetchSubjectProvider, FetchSubjectProvider>();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

           
            app.UseMvc(route =>
            {
                route.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=index}/{id?}");
            });
        }
    }
}
