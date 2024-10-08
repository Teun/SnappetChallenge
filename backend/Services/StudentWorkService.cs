using backend.Helpers;
using backend.Models;

namespace backend.Services;

public class StudentWorkService : IStudentWorkService
{
    // This could be a DbContext if you're using EF Core, or any data access service.
    private readonly List<StudentWork> _studentWorks;

    public StudentWorkService()
    {
        // Dummy data for the sake of the example.
        _studentWorks =  Json.LoadJson<StudentWork>("./Data/work.json");
    }

    public List<StudentWork> GetAllStudentWorks()
    {
        return _studentWorks;
    }

    public List<StudentWork> GetStudentWorksBySubmitDateTime(DateTime submitDateTime)
    {
        return _studentWorks.Where(sw => sw.SubmitDateTime.Year == submitDateTime.Year && sw.SubmitDateTime.Month == submitDateTime.Month && sw.SubmitDateTime.Day == submitDateTime.Day).ToList();
    }

    public int GetSubmissionCountBySubmitDateTime(DateTime submitDateTime)
    {
        List<StudentWork> studentWorks = GetStudentWorksBySubmitDateTime(submitDateTime);
        return studentWorks.Count;
    }

    public List<SubjectScore> GetAverageScoreOfSubjectBySubmitDateTime(DateTime submitDateTime)
    {
        List<StudentWork> studentWorks = GetStudentWorksBySubmitDateTime(submitDateTime);
        List<SubjectScore> subjectScores = studentWorks.Where(sw => sw.Correct == 1)  // Filter correct submissions
            .GroupBy(sw => sw.Subject)
            .Select(group => new SubjectScore
            {
                Subject = group.Key,
                Score = group.Average(sw => sw.Correct)
            })
            .ToList();
        return subjectScores;
    }

    public List<StudentPerformance> GetTopPerformingStudentsBySubmitDateTime(DateTime submitDateTime, int limit)
    {
        List<StudentWork> studentWorks = GetStudentWorksBySubmitDateTime(submitDateTime);
        List<StudentPerformance> topPerformingStudents = studentWorks
            .Where(sw => sw.Correct == 1)  // Filter correct submissions
            .GroupBy(sw => sw.UserId)
            .Select(group => new StudentPerformance
            {
                UserId = group.Key,
                CorrectSubmissions = group.Count()
            })
            .OrderByDescending(x => x.CorrectSubmissions)
            .Take(limit)
            .ToList();
        return topPerformingStudents;
    }
}
