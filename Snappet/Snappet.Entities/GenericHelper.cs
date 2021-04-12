using Newtonsoft.Json;
using Snappet.Entities.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Snappet.Entities
{
    public static class GenericHelper
    {
        public static IEnumerable<Summary> LoadSummaryFromFile()
        {
            string jsonString = File.ReadAllText(@"../../Data/work.json");
            IEnumerable<Summary> summaryList = JsonConvert.DeserializeObject<IEnumerable<Summary>>(jsonString);
            return summaryList;
        }
    }
}
