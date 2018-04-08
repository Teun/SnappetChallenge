using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Data.OData.Metadata;
using Newtonsoft.Json;
using Snappet.Challenge.Web.Core.Models;
using Snappet.Challenge.Web.Helpers;

namespace Snappet.Challenge.Web.Data
{
    public class Context : IContext
    {
        public IEnumerable<Work> Data
        {
            get { return Context.LoadData(); }
        }

        private static IEnumerable<Work> LoadData()
        {
            var filePath =
                @"/Users/marco/Documents/Desenvolvimento/Projetos/netcore/Snappet/Snappet.Challenge.Web/Data/work.json";
            var workList = JsonConvert.DeserializeObject<List<Work>>(File.ReadAllText(filePath),
                new JsonSerializerSettings() {NullValueHandling = NullValueHandling.Include});

            //Exclude data in the future.
            return workList.Where(w => w.SubmitDateTime <= new DateTime().NowAtSnappet());
        }
    }
}