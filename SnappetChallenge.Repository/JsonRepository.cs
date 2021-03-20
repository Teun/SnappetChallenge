using LazyCache;
using Microsoft.Extensions.Options;
using SnappetChallenge.Repository.Config;
using SnappetChallenge.Repository.Interfaces;
using SnappetChallenge.Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnappetChallenge.Repository
{
    public class JsonRepository : IRepository
    {
        private readonly RepositoryOptions _repositoryOptions;
        private readonly IFileDataLoader _fileDataLoader;
        private readonly IAppCache _cache;

        public JsonRepository(IOptions<RepositoryOptions> options, IFileDataLoader fileDataLoader, IAppCache cache)
        {
            _repositoryOptions = options.Value;
            _fileDataLoader = fileDataLoader;
            _cache = cache;
        }

        public async Task<IEnumerable<WorkResult>> GetWorkResults() => 
            await _cache.GetOrAddAsync(
                "WorkResults", 
                () => _fileDataLoader.LoadFromFile<WorkResult, WorkResult[]>(_repositoryOptions.JsonFilePath));

    }
}
