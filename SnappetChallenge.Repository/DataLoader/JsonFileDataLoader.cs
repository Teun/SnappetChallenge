using SnappetChallenge.Repository.Interfaces;
using SnappetChallenge.Repository.JsonConvertors;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace SnappetChallenge.Repository.DataLoader
{
    public class JsonFileDataLoader : IFileDataLoader
    {
        public async Task<TResult> LoadFromFile<TModel, TResult>(string relativePath)
        {
            var absolutePath = Path.Combine(AppContext.BaseDirectory, relativePath);

            if (!File.Exists(absolutePath))
            {
                throw new FileNotFoundException("JSON file does not exist. Please ensure that you are using a " +
                    "relative path and that the file is copied to the output directory", absolutePath);
            }

            // Add JSON converter for edge case where one of the DateTime strings has trailing whitespace.
            var options = new JsonSerializerOptions();
            options.Converters.Add(new DateTimeTrimWhitespaceConverter());

            using var fileStream = File.OpenRead(absolutePath);
            var result = await JsonSerializer.DeserializeAsync<TResult>(fileStream, options);
            return result;
        }
    }
}
