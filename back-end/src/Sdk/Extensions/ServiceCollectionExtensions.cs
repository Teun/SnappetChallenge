using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Sdk.Api.Mediatr.PipelinesBehaviours;
using Sdk.Settings;
using Sdk.Swagger;
using System.Collections.Generic;

namespace Sdk.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSdk(this IServiceCollection services, IConfiguration configuration)
        {
            AddSwagger(services, configuration);
            AddPipelineBehaviors(services);
        }

        public static void AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            string apiName = configuration.GetSection("ApiCoreSettings").Get<ApiCoreSettings>().ApiName ?? string.Empty;

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = apiName, Version = "v1" });

                const string bearerSecurityDefinitionId = "Bearer";
                options.AddSecurityDefinition(bearerSecurityDefinitionId, new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    In = ParameterLocation.Header,
                    Scheme = "bearer",
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
                    Name = "Authorization"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = bearerSecurityDefinitionId
                            }
                        },
                        new List<string>()
                    }
                });

                options.OperationFilter<RequiredHeadersOperationFilter>();
            });

            services.AddSwaggerGenNewtonsoftSupport();
        }

        public static void AddPipelineBehaviors(IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationPipelineBehavior<,>));
        }
    }
}
