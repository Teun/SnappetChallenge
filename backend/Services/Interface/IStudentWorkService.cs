using backend.Models;

namespace backend.Services;

public interface IStudentWorkService
{
    List<StudentWork> GetAllStudentWorks();

    List<StudentWork> GetStudentWorksBySubmitDateTime(DateTime submitDateTime);

    int GetSubmissionCountBySubmitDateTime(DateTime submitDateTime);
    
    List<SubjectScore> GetAverageScoreOfSubjectBySubmitDateTime(DateTime submitDateTime);

    List<StudentPerformance> GetTopPerformingStudentsBySubmitDateTime(DateTime submitDateTime, int limit);
}
