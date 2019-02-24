using Microsoft.Extensions.DependencyInjection;
using SnappetDomain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnappetDomain
{
    public static class SnappetDomainExt
    {
        public static IServiceCollection AddSnappetDomain(this IServiceCollection services)
        {
            services.AddTransient<ISnappetService, SnappetService>();
            return services;
        }
    }
}
