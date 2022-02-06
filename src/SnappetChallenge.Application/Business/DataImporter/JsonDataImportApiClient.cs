using Microsoft.Extensions.Configuration;
using SnappetChallenge.Application.Constants;
using SnappetChallenge.Application.Interfaces;

namespace SnappetChallenge.Application.Business.DataImporter;

public class JsonDataImportApiClient : IDataImportApiClient
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;

    public JsonDataImportApiClient(
        IConfiguration configuration,
        HttpClient httpClient)
    {
        httpClient.BaseAddress = new Uri(configuration.GetValue<string>(ConfigurationConstants.IMPORTFILE_BASEURI));

        _configuration = configuration;
        _httpClient = httpClient;
    }

    public async Task<Result<Stream>> DownloadFileStreamAsync(CancellationToken cancellationToken)
    {
        var response = await _httpClient.SendAsync(
            new HttpRequestMessage(HttpMethod.Get, _configuration.GetValue<string>(ConfigurationConstants.IMPORTFILE_FILEPATH)),
            cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return new Result<Stream>(new Exception("Opssss! something went wrong. TODO!"));
        }

        return new Result<Stream>(await response.Content.ReadAsStreamAsync(cancellationToken));
    }
}
