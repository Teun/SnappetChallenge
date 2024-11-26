namespace SnappetChallenge.Classroom.Infrastructure.Repositories;

public interface IReadonlyClassroomRepository
{
    public Task<ViewModels.ClassroomResponse> GetClassroomOverviewAsync(
        int classroomId, DateTime currentDate, CancellationToken cancellationToken);

}