using backend.Helpers;
using backend.Models;

namespace backend.Services;

public class StudentWorkService : IStudentWorkService
{
    // This could be a DbContext if you're using EF Core, or any data access service.
    private readonly List<StudentWork> _studentWorks;

    public StudentWorkService(string jsonPath = "./Data/work.json")
    {
        if (File.Exists(jsonPath))
        {
            _studentWorks = Json.LoadJson<StudentWork>(jsonPath);
        }
        else
        {
            throw new FileNotFoundException("The specified JSON file was not found.", jsonPath);
        }
    }

    public List<StudentWork> GetAllStudentWorks()
    {
        return _studentWorks;
    }

    public IEnumerable<StudentWork> GetStudentWorksBySubmitDateTime(DateTime submitDateTime)
    {
        return _studentWorks
            .Where(work =>
                    work.SubmitDateTime.Date == submitDateTime.Date
                    && work.SubmitDateTime < submitDateTime);
    }

    public int GetSubmissionCountBySubmitDateTime(DateTime submitDateTime)
    {
        return GetStudentWorksBySubmitDateTime(submitDateTime).Count();
    }

    public List<SubjectProgress> GetAverageScoreOfSubjectBySubmitDateTime(DateTime submitDateTime)
    {
        IEnumerable<StudentWork> studentWorks = GetStudentWorksBySubmitDateTime(submitDateTime);
        List<SubjectProgress> SubjectProgresss = studentWorks
            .GroupBy(sw => sw.Subject)
            .Select(group => new SubjectProgress
            {
                Subject = group.Key,
                AverageProgress = group
                    .GroupBy(sw => sw.UserId)
                    .Average(userGroup => userGroup.Sum(work => work.Progress)),
                IncorrectPercentage = (double)group.Count(sw => sw.Correct == 0) / group.Count() * 100
            })
            .ToList();
            
        return SubjectProgresss;
    }

    public List<StudentPerformance> GetStudentPerformancesBySubmitDateTime(DateTime submitDateTime)
    {
        // We should use a cache here if there's more time

        IEnumerable<StudentWork> studentWorks = GetStudentWorksBySubmitDateTime(submitDateTime);
        List<StudentPerformance> studentPerformances = studentWorks
            .GroupBy(sw => sw.UserId)
            .Select(group => new StudentPerformance
            {
                UserId = group.Key,
                CorrectSubmissions = group.Count(sw => sw.Correct == 1),
                IncorrectSubmissions = group.Count(sw => sw.Correct == 0),
                TotalProgress = group.Sum(sw => sw.Progress)
            })
            .ToList();

        return studentPerformances;
    }
}
