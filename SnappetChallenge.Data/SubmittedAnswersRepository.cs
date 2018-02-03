using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using SnappetChallenge.Data.Models;

namespace SnappetChallenge.Data
{
    public class SubmittedAnswersRepository : ISubmittedAnswersRepository
    {
        public IQueryable<SubmittedAnswerDb> Query()
        {
            using (var contentStream = File.OpenRead("work.json"))
            {
                using (var streamReader = new StreamReader(contentStream))
                {
                    var nowUtc = DateTime.Parse("2015-03-24T11:30:00Z")
                        .ToUniversalTime();
                    var serializer = new JsonSerializer();
                    serializer.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                    return serializer.Deserialize<IEnumerable<SubmittedAnswerDb>>(
                        new JsonTextReader(streamReader)).AsQueryable()
                            .Where(a => a.SubmitDateTime < nowUtc);
                }
            }
        }
    }
}