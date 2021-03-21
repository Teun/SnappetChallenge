using Microsoft.Extensions.DependencyInjection;

namespace Snappet.API.Extensions
{
    public static class Services
    {
        /// <summary>
        /// Add default ORM
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString">Database connection string</param>
        public static void AddORM(this IServiceCollection services)
        {
            var dapper = new Logic.Database.DatabaseContextDapper();
            services.AddSingleton<Logic.Database.IDatabaseContext>(dapper);
        }
    }
}
