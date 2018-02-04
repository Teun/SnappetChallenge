namespace SnappetChallenge.WebUI.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Configuration;

    using SnappetChallenge.WebUI.Models;

    public class DataService : IDataService
    {
        private HttpClient client;

        private string configEndpointGetter = "DataService:Endpoint";

        private string studentsResultEndpoint = "api/StudentsWorkingResult/from/{0}/to/{1}";

        public DataService(IConfiguration configuration)
        {
            this.client = new HttpClient();
            this.client.BaseAddress = new Uri(configuration[this.configEndpointGetter]);
        }

        public async Task<IEnumerable<StudentResultModel>> GetByDate(DateTime @from, DateTime to)
        {
            IEnumerable<StudentResultModel> result = null;
            var utcFrom = DateTime.SpecifyKind(@from, DateTimeKind.Utc);
            var utcTo = DateTime.SpecifyKind(to, DateTimeKind.Utc);

            HttpResponseMessage response = await this.client.GetAsync(
                string.Format(this.studentsResultEndpoint, utcFrom.ToString("O"), utcTo.ToString("O")));

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<IEnumerable<StudentResultModel>>();
            }

            return result;
        }
    }
}
