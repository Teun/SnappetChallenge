// <copyright file="Startup.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>

namespace Nicollas
{
    using System;
    using System.Globalization;
    using AutoMapper;
    using Microsoft.AspNetCore.Antiforgery;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Authorization;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Nicollas.Ng;
    using Nicollas.Ng.Filters;

    /// <summary>
    /// The Partial Startup class
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        public void ConfigureServices(IServiceCollection services)
        {
            this.AddDependencyInjection(services);

            // Only enable request for localhost on development, otherwise we have securety problems
            if (this.Configuration.GetValue<bool>("EnableCors", false))
            {
                services.AddCors();
            }

            this.ConfigureAuth(services);

            services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");

            // Make authentication compulsory across the board (i.e. shutdown EVERYTHING unless explicitly opened up).
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build();

                config.Filters.Add(new AuthorizeFilter(policy));
                config.Filters.Add(new GlobalExceptionFilter(new NLogLogger()));
            }).AddJsonOptions(jsonOptions =>
            {
                // jsonOptions.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                jsonOptions.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                jsonOptions.SerializerSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Include;
                jsonOptions.SerializerSettings.Culture = CultureInfo.GetCultureInfo("EN-US");
            });

            // Session Storage
            services.AddDistributedMemoryCache();
            services.AddSession();

            // services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(@"\\server\share\directory\"));

            // AutoMapper inject dep
            services.AddAutoMapper(typeof(Startup));
            services.AddApplicationInsightsTelemetry(this.Configuration);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        /// <param name="env">IHostingEnvironment</param>
        /// <param name="loggerFactory">ILoggerFactory</param>
        /// <param name="antiforgery">IAntiforgery</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IAntiforgery antiforgery)
        {
            // Only enable request for localhost on development, otherwise we have securety problems
            if (this.Configuration.GetValue<bool>("EnableCors", false))
            {
                app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().Build());
            }

            this.AddTokenProvider(app);
            this.ConfigureSocket(app);

            app.Use(next => context =>
            {
                if (string.Equals(context.Request.Path.Value, "/", StringComparison.OrdinalIgnoreCase))
                {
                    var tokens = antiforgery.GetAndStoreTokens(context);
                    context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken, new CookieOptions() { HttpOnly = false });
                }

                return next(context);
            });

            if (env.IsDevelopment())
            {
                loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();

                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler(
                options =>
                {
                    options.Run(
                        async context =>
                        {
                            context.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                            context.Response.ContentType = "text/html";
                            var ex = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
                            if (ex != null)
                            {
                                var err = $"<h1>Error: {ex.Error.Message}</h1>{ex.Error.StackTrace}";
                                await context.Response.WriteAsync(err).ConfigureAwait(false);
                            }
                        });
                });
                app.UseExceptionHandler("/Home/Error");

                // app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            // to validate the JWT auth. If remove, all request will be unauthorized
            app.UseAuthentication();

            // enable session before MVC
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "restful-routes",
                    template: "api/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "asp-mvc-routes",
                    template: "{*url}",
                    defaults: new { controller = "View", action = "Index" });
            });
        }
    }
}
