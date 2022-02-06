using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SnappetChallenge.Application.Interfaces;
using SnappetChallenge.Domain.Entities;
using Newtonsoft.Json;

namespace SnappetChallenge.Application.Business.DataImporter;

public class JsonDataImportProvider : IDataImportProvider
{
    private readonly ILogger<JsonDataImportProvider> _logger;
    private readonly IConfiguration _configuration;
    private readonly IDataImportApiClient _dataImportApiClient;
    private readonly ISubmittedAnswerRepository _importFileRepository;

    public JsonDataImportProvider(
        ILogger<JsonDataImportProvider> logger,
        IConfiguration configuration,
        IDataImportApiClient dataImportApiClient,
        ISubmittedAnswerRepository showService)
    {
        _logger = logger;
        _configuration = configuration;
        _dataImportApiClient = dataImportApiClient;
        _importFileRepository = showService;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        if (await _importFileRepository.GetSubmittedAnswerCountAsync() > 0)
        {
            return;
        }

        var result = await _dataImportApiClient.DownloadFileStreamAsync(cancellationToken);
        if (!result.IsSuccess)
        {
            throw new Exception("TODO!");
        }

        await ProcessFileStreamAsync(result.Data, cancellationToken);
    }


    private async Task ProcessFileStreamAsync(Stream stream, CancellationToken cancellationToken)
    {
        var answers = new List<SubmittedAnswer>();
        using (var streamReader = new StreamReader(stream))
        using (var reader = new JsonTextReader(streamReader))
        {
            var serializer = new JsonSerializer();
            while (await reader.ReadAsync(cancellationToken))
            {
                if (reader.TokenType == JsonToken.StartObject)
                {
                    answers.Add(serializer.Deserialize<SubmittedAnswer>(reader));
                    if (answers.Count == 100)
                    {
                        //persist one batch
                        await PersistAnswersAsync(answers, cancellationToken);
                        answers.Clear();
                    }
                }
            }
            //persist the remaining
            if (answers.Count > 0)
            {
                await PersistAnswersAsync(answers, cancellationToken);
            }
        }
    }

    private async Task PersistAnswersAsync(IEnumerable<SubmittedAnswer> answers, CancellationToken cancellationToken)
    {
        await _importFileRepository.AddSubmittedAnswerAsync(answers, cancellationToken);
    }
}
