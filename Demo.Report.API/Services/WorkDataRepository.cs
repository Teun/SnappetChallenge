// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="WorkDataProvider.cs" company="Noordhoff Uitgevers BV">
//      © Noordhoff Uitgevers BV, the Netherlands
//  </copyright>
//  <author>Valiukevich, Evgeny</author>
// --------------------------------------------------------------------------------------------------------------------
namespace Demo.Report.API.Services
{
    using System.Collections.Generic;
    using System.IO;
    using Model;
    using Newtonsoft.Json;

    public class WorkDataRepository
    {
        private string path;

        public WorkDataRepository(string path)
        {
            this.path = path;
        }

        public IEnumerable<UserWorkItem> LoadAll()
        {
            var content = File.ReadAllText(path);
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };
            var items = JsonConvert.DeserializeObject<UserWorkItem[]>(content, jsonSerializerSettings);
            return items;
        }
    }
}