using ClassMonitor.Core.Interfaces;
using ClassMonitor.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ClassMonitor.Core
{
    public static class Extensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentProgressService, StudentProgressService>();

            return services;
        }
    }
}
