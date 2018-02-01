using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetChallenge.WebApi.Helpers
{
    using System.IO;

    using Microsoft.Extensions.Configuration;

    using Newtonsoft.Json;

    using SnappetChallenge.WebApi.Models;
    public class FileRepository : IFileRepository<ExerciseResultModel>, IFileOpener
    {
        private string fullFilePath;

        public FileRepository(IConfiguration configuration)
        {
            this.InitializeDataFileFullPath(configuration);
        }

        public IList<ExerciseResultModel> GetByData(DateTime @from, DateTime to)
        {
            var result = new List<ExerciseResultModel>();

            var serializer = new JsonSerializer();
            using (var stream = this.OpenJsonData())
            using (var streamReader = new StreamReader(stream))
            using (JsonReader reader = new JsonTextReader(streamReader))
            {
                while (reader.Read())
                {
                    if (reader.TokenType != JsonToken.StartObject) continue;

                    ExerciseResultModel item = serializer.Deserialize<ExerciseResultModel>(reader);

                    if (item.SubmitDateTime >= @from && item.SubmitDateTime <= to)
                    {
                        result.Add(item);
                    }
                }
            }

            return result;
        }

        public Stream OpenJsonData()
        {
            return File.Open(this.fullFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        }

        private void InitializeDataFileFullPath(IConfiguration configuration)
        {
            var root = Directory.GetCurrentDirectory();

            var folderName = configuration["Data:FolderName"];
            if (folderName == null)
            {
                throw new NullReferenceException("Folder name with data files isn't specified in appsettings.json");
            }

            var jsonFile = configuration["Data:Files:Json"];
            if (jsonFile == null)
            {
                throw new NullReferenceException("File with .json extension isn't specified in appsettings.json");
            }

            fullFilePath = Path.Combine(root, folderName, jsonFile);
        }
    }
}
