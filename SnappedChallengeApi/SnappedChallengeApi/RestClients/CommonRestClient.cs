using Newtonsoft.Json;
using SnappedChallengeApi._Corelib.Extensions;
using SnappedChallengeApi._Corelib.GenericPatterns;
using SnappedChallengeApi._Corelib.RestClient;
using SnappedChallengeApi._Corelib.RestClient.Request;
using SnappedChallengeApi._Corelib.RestClient.Response;
using SnappedChallengeApi.Models.Commons;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SnappedChallengeApi.RestClients
{
    /// <summary>
    /// Common controller rest client helper
    /// </summary>
    public class CommonRestClient: Singleton<CommonRestClient>
    {
        /// <summary>
        /// Get Ping Api Result
        /// </summary>
        /// <returns></returns>
        public async Task<bool> GetPingResult()
        {
            RestRequestParameter parameters = new RestRequestParameter(
                ServiceSettings.ServiceAddress.GetRequestUrl($"/api/ping"),
                HttpMethod.Get)
            { IgnoreCertificateErrors = true };

            RestServiceClient client = new RestServiceClient();
            RestServiceCallResponse result = await client.CallRestServiceAsync<String>(parameters);

            var resultObject = JsonConvert.DeserializeObject<bool>(result.ResultObject.ToString());

            return resultObject;
        }
    }
}
