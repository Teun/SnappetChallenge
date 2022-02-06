using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SnappetChallenge.Application.Business.DataImporter;
using SnappetChallenge.Application.Business.Repository;
using SnappetChallenge.Application.Business.Services;
using SnappetChallenge.Application.Http;
using SnappetChallenge.Application.Interfaces;
using SnappetChallenge.Application.Providers;
using System.Reflection;

namespace SnappetChallenge.Application.IoC;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services, bool isConsoleApp = false)
    {
        if (!isConsoleApp)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
        else
        {
            services.AddHttpClient<IDataImportApiClient, JsonDataImportApiClient>()
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .AddPolicyHandler((services, request) => HttpHandlerPolicies.Get429RetryPolicy(services));
            services.AddTransient<IDataImportProvider, JsonDataImportProvider>();
        }
        services.AddTransient<ISubmittedAnswerService, SubmittedAnswerService>();
        services.AddTransient<ISubmittedAnswerRepository, SubmittedAnswerRepository>();
        services.AddSingleton<IDateProvider, DateProvider>();

        return services;
    }
}
