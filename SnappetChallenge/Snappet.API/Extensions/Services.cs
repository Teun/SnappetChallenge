using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag.Generation.Processors.Security;

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


        /// <summary>
        /// Set swagger setttings
        /// </summary>
        /// <param name="services"></param>
        public static void setSwaggerSettings(this IServiceCollection services)
        {
            services.AddSwaggerDocument(c =>
            {
                c.DocumentName = "Snappet code challenge, 1.0.0";
                c.Title = "Snappet code challenge API Document";
                c.Description = "Snappet code challenge API {GET,Post,Put,Delete}";
                c.OperationProcessors.Add(new OperationSecurityScopeProcessor("Bearer"));
                c.GenerateExamples = true;
                c.GenerateCustomNullableProperties = true;
                c.AllowNullableBodyParameters = true;
                c.AddSecurity("Bearer", new NSwag.OpenApiSecurityScheme()
                {
                    Description = "WT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = NSwag.OpenApiSecurityApiKeyLocation.Header,
                    Type = NSwag.OpenApiSecuritySchemeType.ApiKey,
                    BearerFormat = "Authorization: Bearer {token}"
                });
            });
        }
    }
}
