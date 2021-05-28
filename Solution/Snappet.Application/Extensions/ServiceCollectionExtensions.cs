using Microsoft.Extensions.DependencyInjection;
using Snappet.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snappet.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStatsProcessingService, StatsProcessingService>();
        }
    }
}
