using SnappetChallenge.Application;
using SnappetChallenge.Domain.Entities;

namespace SnappetChallenge.Application.Interfaces;

public interface IDataImportApiClient
{
    Task<Result<Stream>> DownloadFileStreamAsync(CancellationToken cancellationToken);
}
