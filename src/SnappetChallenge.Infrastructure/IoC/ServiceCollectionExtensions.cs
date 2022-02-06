using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SnappetChallenge.Infrastructure.Database;
using SnappetChallenge.Application.Interfaces;

namespace SnappetChallenge.Infrastructure.IoC;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IDatabaseBootstrapper, SQLiteDatabaseBootstrapper>();
        services.AddTransient<IDbContext, SQLiteDapperContext>();
        SqlMapper.AddTypeHandler(new SQLiteGuidTypeHandler());
        SqlMapper.RemoveTypeMap(typeof(Guid));
        SqlMapper.RemoveTypeMap(typeof(Guid?));

        return services;
    }
}
