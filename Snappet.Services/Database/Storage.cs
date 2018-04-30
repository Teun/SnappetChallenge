using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Snappet.Common.Checks;
using Snappet.Common.Configurations;
using Snappet.Common.JsonConverters;
using Snappet.Contracts.Assesments.Models;
using Snappet.Contracts.ConfigrationSettings;
using Snappet.Contracts.Databases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Snappet.Services.Database
{
    public class Storage : IStorage
    {        
        private readonly string filePath;

        private TotalResult TotalResult { get; set; }

        public Storage(IOptions<ConfigurationSettings> settings)
        {
            filePath = settings.Value.PathToDbFile;
            TotalResult = new TotalResult();
        }

        private void Load()
        {
            Check.That(!string.IsNullOrEmpty(filePath), "Please, make sure that path to dataset file is correct...");

            try
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    TotalResult.ExcercisesResults = CustomJsonConverter.DeserializeFromStream<List<ExcerciseResult>>(fs);                    
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public TotalResult GetWorksResult()
        {
            if (TotalResult.ExcercisesResults == null)
                Load();

            return TotalResult;
        }
    }
}
