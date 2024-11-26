using SnappetChallenge.Classroom.Infrastructure.Repositories;

namespace SnappetChallenge.Classroom.Api.Extensions;

public static class RepositoriesExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddScoped<IReadonlyClassroomRepository, ReadOnlyClassroomRepository>()
            .AddScoped<IClassroomRepository, ClassroomRepository>();
    }
}