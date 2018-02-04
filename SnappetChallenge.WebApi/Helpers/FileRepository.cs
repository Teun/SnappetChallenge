namespace SnappetChallenge.WebApi.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using Newtonsoft.Json;

    using SnappetChallenge.WebApi.Models;

    public class FileRepository : IFileRepository<ExerciseResultJsonDeserializeModel>, IFileOpener
    {
        private string rootFolderName = "SnappetChallenge";

        private string dataFolderName = "Data";

        private string fileName = "work.json";

        private readonly string fullFilePath;

        public FileRepository()
        {
            var projectName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            DirectoryInfo currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());

            var rootFolder = this.GetRoot(currentDirectory);

            this.fullFilePath = Path.Combine(rootFolder.FullName, projectName, this.dataFolderName, this.fileName);
        }

        public IList<ExerciseResultJsonDeserializeModel> GetByData(DateTime @from, DateTime to)
        {
            var result = new List<ExerciseResultJsonDeserializeModel>();

            var serializer = new JsonSerializer();
            using (var stream = this.OpenJsonData())
            using (var streamReader = new StreamReader(stream))
            using (JsonReader reader = new JsonTextReader(streamReader))
            {
                while (reader.Read())
                {
                    if (reader.TokenType != JsonToken.StartObject)
                    {
                        continue;
                    }

                    ExerciseResultJsonDeserializeModel item = serializer.Deserialize<ExerciseResultJsonDeserializeModel>(reader);

                    if (item.SubmitDateTime >= @from && item.SubmitDateTime <= to)
                    {
                        result.Add(item);
                    }
                }
            }

            return result;
        }

        public IEnumerable<StudentResultModel> GetGroupedListByData(DateTime @from, DateTime to)
        {
            IList<ExerciseResultJsonDeserializeModel> ungroupedData = this.GetByData(from, to);

            IEnumerable<StudentResultModel> students = 
                ungroupedData?.GroupBy(x => x.UserId, (key, group) => new StudentResultModel(key, group));

            return students;
        }

        public Stream OpenJsonData()
        {
            return File.Open(this.fullFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        }

        private DirectoryInfo GetRoot(DirectoryInfo directory)
        {
            var parent = directory.Parent;

            if (parent == null)
            {
                throw new NullReferenceException($"Unable to find root directory \"{this.rootFolderName}\"");
            }

            if (parent.Name == this.rootFolderName)
            {
                return parent;
            }

            return this.GetRoot(parent);
        }
    }
}
