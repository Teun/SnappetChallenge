using SnappetServices.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetServices.Repositories
{
    public class ResultsRepository: IResultsRepository
    {
        public List<Result> GetAllResults(string date = null)
        {
            var results = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Result>>(File.ReadAllText("data/work.json"));
            return results;
        }
    }
}
