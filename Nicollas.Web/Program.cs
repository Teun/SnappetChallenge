// <copyright file="Program.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>

namespace Nicollas
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Nicollas.Core;
    using Nicollas.Core.Entities.Identity;
    using Nicollas.SqlServer;

    /// <summary>
    /// The startup class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Gets the IWebHost
        /// </summary>
        internal static IWebHost Host { get; private set; }

        /// <summary>
        /// The Startup Method
        /// </summary>
        /// <param name="args">The Startup Arguments</param>
        public static void Main(string[] args)
        {
            Program.Host = BuildWebHost(args);

            using (var scope = Program.Host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var environment = services.GetRequiredService<IHostingEnvironment>();
                    if (!environment.IsDevelopment())
                    {
                        NicollasDbInitializer.Initialize(services.GetRequiredService<IDbContext>());
                    }

                    var worker = services.GetRequiredService<IUnitOfWork>();
                    NicollasDbInitializer.Seed(
                         worker,
                         services.GetRequiredService<Microsoft.AspNetCore.Identity.UserManager<User>>(),
                         services.GetRequiredService<Microsoft.AspNetCore.Identity.RoleManager<Role>>()); // <---Do your seeding here
                }
                catch (System.Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            Host.Run();
        }

        /// <summary>
        /// Build the WebHost
        /// </summary>
        /// <param name="args">The Startu Arguments</param>
        /// <returns>A <see cref="IWebHost"/></returns>
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseDefaultServiceProvider(options => options.ValidateScopes = false)
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    var env = hostContext.HostingEnvironment;

                    // delete all default configuration providers
                    config.Sources.Clear();
                    config
                    .AddJsonFile($"Settings/appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"Settings/appsettings.jwt.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"Settings/appsettings.providers.{env.EnvironmentName}.json", optional: true);
                })
                .Build();
    }
}
