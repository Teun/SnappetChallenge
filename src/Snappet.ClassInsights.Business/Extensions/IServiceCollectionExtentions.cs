using Microsoft.Extensions.DependencyInjection;
using Snappet.ClassInsights.Business.Services;

namespace Snappet.ClassInsights.Business.Extensions
{
    public static class IServiceCollectionExtentions
    {
        public static void AddClassInsightsServices(this IServiceCollection services)
        { 
            services.AddScoped<IInsightsService, InsightsService>(); 
        }
    }
}
