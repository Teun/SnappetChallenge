using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
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


        /// <summary>
        /// Setup JWT validator
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddJWT(this IServiceCollection services, IConfiguration configuration)
        {
            string key = configuration.GetValue<string>("JWT:Key");
            string issuer = configuration.GetValue<string>("JWT:Issuer");

            //When a request receive, this operations check the JWT and set User object
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = Logic.Security.JWT.GetTokenValidationParameters(key, issuer);
                    options.Events = Logic.Security.JWT.GetJWTEvents();
                });
        }
    }
}
