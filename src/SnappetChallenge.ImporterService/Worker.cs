using Dapper;
using System.Data;
using System.Threading.Tasks.Dataflow;
using System.Transactions;
using SnappetChallenge.Application.Interfaces;
using SnappetChallenge.Domain.Entities;
using SnappetChallenge.Infrastructure.Database;

namespace SnappetChallenge.ImporterService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IDataImportProvider _dataImportProvider;

    public Worker(
        ILogger<Worker> logger,
        IDataImportProvider dataImportProvider)
    {
        _logger = logger;
        _dataImportProvider = dataImportProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _dataImportProvider.StartAsync(stoppingToken);
        _logger.LogInformation("Done! We are finished.");
    }
}






