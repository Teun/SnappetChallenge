using Newtonsoft.Json;
using Snappet.Entities.Entities;
using System.Collections.Generic;
using System.IO;

namespace Snappet.Entities
{
    /// <summary>
    /// Generic helper
    /// </summary>
    public static class GenericHelper
    {
        /// <summary>
        /// Reads the data in json format and loads into list of summary
        /// </summary>
        /// <returns>List of summary</returns>
        public static IEnumerable<Summary> LoadSummaryFromFile()
        {
            string jsonString = File.ReadAllText(@"../../Data/work.json");
            IEnumerable<Summary> summaryList = JsonConvert.DeserializeObject<IEnumerable<Summary>>(jsonString);
            return summaryList;
        }
    }
}
