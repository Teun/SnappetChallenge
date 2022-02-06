using SnappetChallenge.Application.Business.Results;
using SnappetChallenge.Domain.Entities;

namespace SnappetChallenge.Application.Interfaces;

public interface ISubmittedAnswerService
{
    Task<GetProgressReportResult> GetProgressReportAsync(DateTime date);
}
