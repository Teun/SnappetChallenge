using Microsoft.Extensions.Logging;
using SnappetChallenge.Classroom.Application.Context;
using SnappetChallenge.Classroom.Domain.Models;

namespace SnappetChallenge.Classroom.Infrastructure.Repositories;

public class ClassroomRepository(ILogger<ReadOnlyClassroomRepository> logger, IClassroomDbContext dbContext) : IClassroomRepository
{
    public async Task SaveAsync(StudentProgress obj, CancellationToken cancellationToken = default)
    {
        await dbContext.StudentProgress.AddAsync(obj, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}