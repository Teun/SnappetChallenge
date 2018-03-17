// <copyright file="Startup.DependencyInjection.cs" company="Soulft">
// Copyright (c) Soulft. All rights reserved.
// </copyright>

namespace Nicollas
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Nicollas.Core;
    using Nicollas.Core.Entities.Identity;
    using Nicollas.Core.Factories;
    using Nicollas.Core.Services;
    using Nicollas.Core.Services.Identity;
    using Nicollas.Identity;
    using Nicollas.Imp.Factory;
    using Nicollas.Imp.Services;
    using Nicollas.Ng;
    using Nicollas.Ng.Extensions;
    using Nicollas.Ng.Filters.Adwords;
    using Nicollas.Service.Services.Identity;
    using Nicollas.Services.Identity;
    using Nicollas.SqlServer;
    using Nicollas.SqlServer.Identity;

    /// <summary>
    /// The Partial Startup class
    /// </summary>
    public partial class Startup
    {
        private void AddDependencyInjection(IServiceCollection services)
        {
            // Added inject dep
            services.AddScoped<IDbContext>(_ => new NicollasContext(this.Configuration.GetConnectionString("DefaultConnection"), new NLogLogger()));
            services.AddSingleton<Core.ILogger, NLogLogger>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IUserStore<User>, NicollasIdentity>();
            services.AddTransient<IRoleStore<Role>, NicollasIdentity>();

            services.AddTransient<IEmailService, EmailService>(_ => EmailService.Create(this.Configuration.GetSection("EmailService")));

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserRoleService, UserRoleService>();

            services.AddTransient<IDomainFactory, DomainFactory>();
            services.AddTransient<ISubjectFactory, SubjectFactory>();
            services.AddTransient<IChartFactory, ChartFactory>();

            services.AddTransient<IEvaluationService, EvaluationService>();

            services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddTransient<ILookupNormalizer, LookupNormalizer>();
            services.AddTransient<IdentityErrorDescriber, IdentityErrorDescriber>();

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>(); // for session Facility
            services.AddTransient<SessionFacility, SessionFacility>(); // for session facility;
            services.AddSingleton<Microsoft.Extensions.Configuration.IConfiguration>(this.Configuration);

            services.AddSingleton<IPathProvider, PathProvider>();

            services.AddTransient<UserManager<User>, ApplicationUserManager>();

            // (factory) => ApplicationUserManager.Create(
            //    factory.GetRequiredService<IUnitOfWork>(),
            //    factory.GetRequiredService<IEmailService>()))
            services.AddTransient<RoleManager<Role>, ApplicationRoleManager>();
        }
    }
}
