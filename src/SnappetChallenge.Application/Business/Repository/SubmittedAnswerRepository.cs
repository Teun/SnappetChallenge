using Dapper;
using SnappetChallenge.Application.Constants;
using SnappetChallenge.Application.Interfaces;
using System.Data;
using SnappetChallenge.Domain.Entities;

namespace SnappetChallenge.Application.Business.Repository;
/// <summary>
/// EF doesnt do well with parallel tasks, that's when Dapper comes in handy
/// </summary>
public class SubmittedAnswerRepository : ISubmittedAnswerRepository
{
    private readonly IDbContext _dbContext;

    public SubmittedAnswerRepository(
        IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AddSubmittedAnswerAsync(
        IEnumerable<SubmittedAnswer> answers,
        CancellationToken cancellationToken)
    {
        using (var connection = _dbContext.CreateConnection())
        {
            await connection.ExecuteAsync(@$"
INSERT 
    INTO {DatabaseConstants.TABLE_SUBMITTEDANSWER_NAME} 
    ({nameof(SubmittedAnswer.SubmittedAnswerId)},
    {nameof(SubmittedAnswer.SubmitDateTime)},
    {nameof(SubmittedAnswer.Correct)},
    {nameof(SubmittedAnswer.Progress)},
    {nameof(SubmittedAnswer.UserId)},
    {nameof(SubmittedAnswer.ExerciseId)},
    {nameof(SubmittedAnswer.Difficulty)},
    {nameof(SubmittedAnswer.Subject)},
    {nameof(SubmittedAnswer.Domain)},
    {nameof(SubmittedAnswer.LearningObjective)})
    VALUES 
    (@SubmittedAnswerId,
    @SubmitDateTime,
    @Correct,
    @Progress,
    @UserId,
    @ExerciseId,
    @Difficulty,
    @Subject,
    @Domain,
    @LearningObjective)
;", answers);
            return true;
        }
    }

    public async Task<int> GetSubmittedAnswerCountAsync()
    {
        using (var connection = _dbContext.CreateConnection())
        {
            return await connection.QueryFirstAsync<int>(@$"
SELECT 
    COUNT(0) 
    FROM {DatabaseConstants.TABLE_SUBMITTEDANSWER_NAME}
;");
        }
    }

    public async Task<IEnumerable<ProgressReportDTO>> GetTodayReportAsync(DateTime date, SubjectType subjectType)
    {
        using (var connection = _dbContext.CreateConnection())
        {
            return await connection.QueryAsync<ProgressReportDTO>(@$"
SELECT 
    SUM(Progress) as Progress, 
    {subjectType} as Data
    FROM {DatabaseConstants.TABLE_SUBMITTEDANSWER_NAME}
    WHERE SubmitDateTime >= @InitialDate AND SubmitDateTime <= @FinalDate
    GROUP BY {subjectType};
;", new { 
            InitialDate = date.ToString("yyyy-MM-dd"),
            FinalDate = date.ToString("yyyy-MM-dd HH:mm:ss")
            });
        }
    }

    public async Task<IEnumerable<ProgressReportDTO>> GetLastWeekDailyAverageReportAsync(DateTime date, SubjectType subjectType)
    {
        //https://stackoverflow.com/questions/658353/calculate-previous-weeks-start-and-end-date
        var mondayOfLastWeek = date.AddDays(-(int)date.DayOfWeek - 6);
        var fridayOfLastWeek = mondayOfLastWeek.AddDays(4);

        using (var connection = _dbContext.CreateConnection())
        {
            return await connection.QueryAsync<ProgressReportDTO>(@$"
SELECT 
    (SUM(Progress) / 5) as Progress, 
    {subjectType} as Data
    FROM {DatabaseConstants.TABLE_SUBMITTEDANSWER_NAME}
    WHERE SubmitDateTime >= @InitialDate AND SubmitDateTime <= @FinalDate
    GROUP BY {subjectType};
;", new
            {
                InitialDate = mondayOfLastWeek.ToString("yyyy-MM-dd"),
                FinalDate = fridayOfLastWeek.ToString("yyyy-MM-dd 23:59:59")
            });
        }
    }
}

public enum SubjectType
{
    Subject = 0,
    Domain = 1
}

public struct ProgressReportDTO
{
    public string Data { get; set; }
    public int Progress { get; set; }
}
