using Microsoft.Extensions.Configuration;
using Snappet.Domain.Interface;
using Snappet.Domain.Interface.Repository;
using Snappet.Domain.Interface.Service;
using Snappet.Infrastructure.Persistence;
using Snappet.Infrastructure.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IDateService, DateService>();
            services.AddSingleton<ISnappetDbContext, DbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<IProgressCalculatorService, ProgressCalculatorService>();
        }
    }
}
