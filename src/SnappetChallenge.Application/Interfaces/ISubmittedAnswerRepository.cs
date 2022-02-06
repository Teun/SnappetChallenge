using System.Data;
using SnappetChallenge.Application.Business.Repository;
using SnappetChallenge.Domain.Entities;

namespace SnappetChallenge.Application.Interfaces;

public interface ISubmittedAnswerRepository
{
    Task<bool> AddSubmittedAnswerAsync(
        IEnumerable<SubmittedAnswer> answers,
        CancellationToken cancellationToken);

    Task<int> GetSubmittedAnswerCountAsync();

    Task<IEnumerable<ProgressReportDTO>> GetTodayReportAsync(DateTime date, SubjectType subjectType);
    Task<IEnumerable<ProgressReportDTO>> GetLastWeekDailyAverageReportAsync(DateTime date, SubjectType subjectType);
}
