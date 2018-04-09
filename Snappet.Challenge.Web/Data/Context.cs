using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.OData.Metadata;
using Newtonsoft.Json;
using Snappet.Challenge.Web.Core.Models;
using Snappet.Challenge.Web.Helpers;

namespace Snappet.Challenge.Web.Data
{
    public class Context : IContext
    {
        private static IHostingEnvironment _env;

        public Context(IHostingEnvironment env)
        {
            Context._env = env;
        }

        public IEnumerable<Work> Data => Context.LoadData();

        private static IEnumerable<Work> LoadData()
        {
            var filePath = Path.Combine(_env.ContentRootPath, "Data/work.json");
            var workList = JsonConvert.DeserializeObject<List<Work>>(File.ReadAllText(filePath),
                new JsonSerializerSettings() {NullValueHandling = NullValueHandling.Include});

            //Exclude any data in the future.
            return workList.Where(w => w.SubmitDateTime <= new DateTime().NowAtSnappet());
        }
    }
}