using SnappetChallenge.Classroom.Domain.Models;

namespace SnappetChallenge.Classroom.Infrastructure.Repositories;

public interface IClassroomRepository
{
    Task SaveAsync(StudentProgress obj, CancellationToken cancellationToken = default);
}