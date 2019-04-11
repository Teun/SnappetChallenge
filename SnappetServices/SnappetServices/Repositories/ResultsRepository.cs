using SnappetServices.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetServices.Repositories
{
    public class ResultsRepository : IResultsRepository
    {
        public IEnumerable<Result> GetAllResults(DateTime dateTime = default(DateTime))
        {
            try
            {
                var results = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Result>>(File.ReadAllText("data/work.json"));

                if (dateTime != default(DateTime))
                {
                    return results.Where(p => p.SubmitDateTime.Date == dateTime.Date);
                }

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
