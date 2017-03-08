using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Snappet.Reporting.Application.Domain.Model;

namespace Snappet.Reporting.Application.Json
{
    public static class FileImporter
    {
        public static IList<Answer> GetAnswers(ILoggerFactory loggerFactory, string filename)
        {
            using (var file = File.OpenText(filename))
            {
                using (var stream = new JsonTextReader(file))
                {
                    var serializer = new JsonSerializer { DateTimeZoneHandling = DateTimeZoneHandling.Utc };
                    serializer.Converters.Add(new DecimalConverter(loggerFactory));
                    return serializer.Deserialize<List<Answer>>(stream);
                }
            }
        }
    }
}