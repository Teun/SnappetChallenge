namespace SnappetChallenge.Application.Interfaces;

public interface IDataImportProvider
{
    Task StartAsync(CancellationToken cancellationToken);
}
