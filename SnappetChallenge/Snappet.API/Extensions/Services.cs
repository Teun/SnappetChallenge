using Microsoft.Extensions.DependencyInjection;

namespace Snappet.API.Extensions
{
    public static class Services
    {
        /// <summary>
        /// Add default mapper
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static void AddMapper(this IServiceCollection services)
        {
            //Create default mapper
            var mapConfig = new AutoMapper.MapperConfiguration(mc =>
            {
                mc.AddProfile(new Logic.CommonOperations.Mapper());
            });

            AutoMapper.IMapper mapper = mapConfig.CreateMapper();
            services.AddSingleton(mapper);
        }


        /// <summary>
        /// Add default ORM
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString">Database connection string</param>
        public static void AddORM(this IServiceCollection services, string connectionString)
        {
            var dapper = new Logic.Database.DatabaseContextDapper(connectionString);
            services.AddSingleton<Logic.Database.IDatabaseContext>(dapper);
        }
    }
}
