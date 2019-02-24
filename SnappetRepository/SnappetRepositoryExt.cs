using Microsoft.Extensions.DependencyInjection;
using SnappetDomain.Repositories;
using SnappetRepository.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnappetRepository
{
    public static class SnappetRepositoryExt
    {
        public static IServiceCollection AddSnappetRepository(this IServiceCollection services)
        {
            services.AddTransient<ISnappetRepository, Repositories.SnappetRepository>();
            services.AddTransient<ISnappetRepositorySeeder, SnappetRepositorySeeder>();
            return services;
        }
    }
}
