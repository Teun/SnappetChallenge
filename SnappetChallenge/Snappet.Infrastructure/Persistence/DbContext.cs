using Snappet.Domain.Models;
using Snappet.Infrastructure.Parsers;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;

namespace Snappet.Infrastructure.Persistence
{
    public class DbContext
    {
        public IEnumerable<ExerciseReportModel> ExerciseReports { get; init; }

        public DbContext()
        {
            // parse json
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Snappet.Infrastructure.DB.work.json";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream, encoding: System.Text.Encoding.UTF8))
            {
                string result = reader.ReadToEnd();
                JsonSerializerOptions options = new JsonSerializerOptions();
                options.Converters.Add(new CustomDateTimeConverter());
                var data = JsonSerializer.Deserialize<IEnumerable<ExerciseReportModel>>(result, options);
                if (data == null)
                {
                    throw new Exception("Failed to parse database");
                };

                ExerciseReports = data;
            }
            
        }
    }
}
