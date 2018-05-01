using Newtonsoft.Json;
using SnappetChallenge.Models;
using SnappetChallenge.Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SnappetChallenge.Service
{
    public class ClassWorkService : IClassWorkService
    {
        private string AzureUrl { get; }
        //cache to avoid redudant requests
        private static IEnumerable<Work> worksCache;
        private static DateTime LastUpdate { get; set; }

        public ClassWorkService(string endpoint)
        {
            AzureUrl = endpoint;
        }

        private bool IsTimeToReferesh()
        {
            return ((DateTime.Now - LastUpdate).TotalMinutes >= 5);// refresh every 5 minutes
        }

        /// <summary>
        /// I hosted in Azure a NodeJs application to return the .json file 
        /// The file itself is large to return without any filter via network.
        /// Due the time, I swited the data source to read the .json file as 
        /// a local embbed resource.
        /// The data url can be checked in https://snappet-challenge.azurewebsites.net/work
        /// </summary>        
        /// <returns></returns>
        private async Task<IEnumerable<Work>> UpdateCache()
        {
            //var worktext = await new HttpClient().GetStringAsync(AzureUrl); -- request that was done to Azure
            var resourceFile = Assembly.GetExecutingAssembly().GetManifestResourceStream("SnappetChallenge.Service.work.json");
            var workText = await new System.IO.StreamReader(resourceFile).ReadToEndAsync();
            worksCache = JsonConvert.DeserializeObject<IEnumerable<Work>>(workText);
            LastUpdate = DateTime.Now;
            return worksCache;
        }

       
        public async Task<IEnumerable<Work>> RetrieveClassWork(DateTime from, DateTime to)
        {
            IEnumerable<Work> works = null;
            
            if (!IsTimeToReferesh())
                works = worksCache;
            else
                works = await UpdateCache();

            return works.Where(x => x.SubmitDateTime >= from && x.SubmitDateTime <= to).ToArray();
        }

        public async Task<IEnumerable<int>> RetrieveStudentsIds()
        {
            IEnumerable<Work> works = null;

            if (!IsTimeToReferesh())
                works = worksCache;
            else
                works = await UpdateCache();

            return works?.Select(x => x.UserId).Distinct();
        }
    }
}