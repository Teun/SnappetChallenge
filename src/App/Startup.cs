namespace App
{
	using System;
	using System.Linq;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.SpaServices.Webpack;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Logging;
	using Persistence;
	using Microsoft.EntityFrameworkCore;
	using Autofac;
	using Autofac.Extensions.DependencyInjection;
	using System.Reflection;
	
	public class Startup
	{
		private const string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=School;Trusted_Connection=True;";

		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; }
		public IContainer ApplicationContainer { get; private set; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			// Add framework services.
			services.AddMvc();

			// Autofac.
			var builder = new ContainerBuilder();
			builder.Register(ctx =>
				{
					var b = new DbContextOptionsBuilder<SchoolContext>();
					b.UseSqlServer(ConnectionString);
					return new SchoolContext(b.Options);
				})
				.AsSelf()
				.As<IUnitOfWork>()
				.InstancePerLifetimeScope();
			builder.Populate(services);
			Assembly assembly = typeof(Startup).GetTypeInfo().Assembly;
			builder.RegisterAssemblyTypes(assembly)
				.Where(t => t.Name.EndsWith("Service"))
				.AsImplementedInterfaces();

			ApplicationContainer = builder.Build();
			return new AutofacServiceProvider(ApplicationContainer);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
				{
					HotModuleReplacement = true,
					ReactHotModuleReplacement = true
				});
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetService<SchoolContext>();
				context.Database.EnsureCreated();
				if (!context.Database.GetPendingMigrations().Any())
				{
					context.Database.Migrate();
				}
				//context.EnsureSeedData();
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

			var appLifetime =
				app.ApplicationServices.GetRequiredService<IApplicationLifetime>();
			appLifetime.ApplicationStopping.Register(
				() => ApplicationContainer.Dispose());
		}
	}
}
