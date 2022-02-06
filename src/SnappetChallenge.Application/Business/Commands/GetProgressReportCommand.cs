using MediatR;
using Microsoft.Extensions.Logging;
using SnappetChallenge.Application.Business.Results;
using SnappetChallenge.Application.Interfaces;
using SnappetChallenge.Application.Providers;

/// <summary>
/// I like keeping the Command and the CommandHandler together 
/// as it provides a better visibility as well as quick access.
/// </summary>
namespace SnappetChallenge.Application.Business.Commands;

public class GetProgressReportCommand : IRequest<GetProgressReportResult>
{
}

public class GetProgressReportResultCommandHandler : IRequestHandler<GetProgressReportCommand, GetProgressReportResult>
{
    private readonly ILogger<GetProgressReportResultCommandHandler> _logger;
    private readonly ISubmittedAnswerService _showService;
    private readonly IDateProvider _dateProvider;

    public GetProgressReportResultCommandHandler(
        ILogger<GetProgressReportResultCommandHandler> logger,
        ISubmittedAnswerService showService,
        IDateProvider dateProvider)
    {
        _logger = logger;
        _showService = showService;
        _dateProvider = dateProvider;
    }

    public async Task<GetProgressReportResult> Handle(GetProgressReportCommand request, CancellationToken cancellationToken)
    {
        var date = _dateProvider.Today();

        return await _showService.GetProgressReportAsync(date);
    }
}
