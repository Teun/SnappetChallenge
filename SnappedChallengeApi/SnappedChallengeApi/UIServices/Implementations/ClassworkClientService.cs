using Newtonsoft.Json;
using SnappedChallengeApi._Corelib.RestClient;
using SnappedChallengeApi._Corelib.RestClient.Request;
using SnappedChallengeApi._Corelib.RestClient.Response;
using SnappedChallengeApi.Models.Bussiness;
using SnappedChallengeApi.Models.Commons;
using SnappedChallengeApi.Models.Commons.ApiCommons;
using SnappedChallengeApi.UIServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SnappedChallengeApi._Corelib.Extensions;

namespace SnappedChallengeApi.UIServices.Implementations
{
    public class ClassworkClientService : IClassworkClientService
    {
        private string _endpointName = "classworks";

        public async Task<List<ClassworkSummary>> GetClassworkSummary(DateTime startDate, DateTime endDate)
        {
            FilterParameter param = new FilterParameter()
            {
                StartDate = startDate,
                EndDate = endDate
            };
            StringContent postContent = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json");
            RestRequestParameter parameters = new RestRequestParameter(
                ServiceSettings.ServiceAddress.GetRequestUrl($"/api/{_endpointName}/summary"), 
                HttpMethod.Post, 
                contentParameter: postContent) { IgnoreCertificateErrors = true };

            RestServiceClient client = new RestServiceClient();
            RestServiceCallResponse result = await client.CallRestServiceAsync<String>(parameters);

            var resultObject = JsonConvert.DeserializeObject<List<ClassworkSummary>>(result.ResultObject.ToString());

            return resultObject;
        }

        
    }
}
