using Microsoft.EntityFrameworkCore;
using SnappetChallenge.Application.Interfaces;
using System.Data;
using SnappetChallenge.Domain.Entities;
using SnappetChallenge.Application.Business.Results;
using SnappetChallenge.Application.Business.Repository;

namespace SnappetChallenge.Application.Business.Services;

public class SubmittedAnswerService : ISubmittedAnswerService
{
    private readonly ISubmittedAnswerRepository _repository;

    public SubmittedAnswerService(
        ISubmittedAnswerRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetProgressReportResult> GetProgressReportAsync(DateTime date)
    {
        var ts = await _repository.GetTodayReportAsync(date, SubjectType.Subject);
        var td = await _repository.GetTodayReportAsync(date, SubjectType.Domain);
        var ls = await _repository.GetLastWeekDailyAverageReportAsync(date, SubjectType.Subject);
        var ld = await _repository.GetLastWeekDailyAverageReportAsync(date, SubjectType.Domain);

        var sc = new ProgressReportCollection();
        sc.AddRange(DataSetColumn.Today, ts.ToList());
        sc.AddRange(DataSetColumn.LastWeek, ls.ToList());

        var dc = new ProgressReportCollection();
        dc.AddRange(DataSetColumn.Today, td.ToList());
        dc.AddRange(DataSetColumn.LastWeek, ld.ToList());

        return new GetProgressReportResult
        {
            ByDomainReportData = dc,
            BySubjectReportData = sc
        };
    }
}