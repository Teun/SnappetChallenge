using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NetCore.BackEnd.DepedencyInjection;
using Newtonsoft.Json;

namespace NetCore.BackEnd
{
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", true, true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			if (services == null)
			{
				throw new ArgumentNullException(nameof(services));
			}

			services.ConfigureDepedencyInjection();
			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy",
					builder => builder
						.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader()
						.AllowCredentials());
			});

			services.AddMvc()
				.AddJsonOptions(options => options
					.SerializerSettings
					.DateTimeZoneHandling = DateTimeZoneHandling.Utc);
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			app.UseCors("CorsPolicy");
			app.UseMvc();
		}
	}
}