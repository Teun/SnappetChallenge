using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Services.Services;
using Services.Constants;
using Services.Entities;
using System;
using System.Linq;

namespace Services.Repositories
{
    public class JsonFileWorkRepository : IWorkRepository
    {
        private readonly IConfigurationRoot _configurationRoot;
        private readonly IFileService _fileService;

        public JsonFileWorkRepository(IConfigurationRoot configurationRoot, IFileService fileService)
        {
            _configurationRoot = configurationRoot;
            _fileService = fileService;
        }

        public IReadOnlyCollection<Work> GetAllWork()
        {
            var serializer = JsonSerializer.Create();
            var pathToWork = _configurationRoot.GetSection(AppSettings.WorkFile).Value;

            using (var jsonReader = new JsonTextReader(_fileService.GetTextReader(pathToWork)))
            {
                return serializer.Deserialize<Work[]>(jsonReader);
            }
        }

        public IReadOnlyCollection<Work> GetCurrentWork(DateTime timestamp)
        {
            var minDateTime = timestamp.Date;
            var maxDateTime = timestamp;
            return GetAllWork()
                .Where(w => w.SubmitDateTime >= minDateTime && w.SubmitDateTime <= timestamp)
                .ToArray();
        }
    }
}
