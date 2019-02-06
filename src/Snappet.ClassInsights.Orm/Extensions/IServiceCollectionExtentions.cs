using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Snappet.ClassInsights.Orm.Extensions
{
    public static class IServiceCollectionExtentions
    {
        public static void AddClassInsightsOrmWithSqlite(this IServiceCollection services, string connectionString)
        {
            services.AddEntityFrameworkSqlite();
            services.AddScoped<IDataSeeder, SqliteDataSeeder>();
            services.AddDbContext<InsightsContext>(options =>
            options.UseSqlite(connectionString));
        }
    }
}
