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
                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<IEnumerable<SubmittedAnswerDb>>(
                        new JsonTextReader(streamReader)).AsQueryable();
                }
            }
        }
    }
}