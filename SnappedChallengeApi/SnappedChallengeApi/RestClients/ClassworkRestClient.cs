using Newtonsoft.Json;
using SnappedChallengeApi._Corelib.Extensions;
using SnappedChallengeApi._Corelib.GenericPatterns;
using SnappedChallengeApi._Corelib.RestClient;
using SnappedChallengeApi._Corelib.RestClient.Request;
using SnappedChallengeApi._Corelib.RestClient.Response;
using SnappedChallengeApi.Models.Bussiness;
using SnappedChallengeApi.Models.Commons;
using SnappedChallengeApi.Models.Commons.ApiCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SnappedChallengeApi.RestClients
{
    /// <summary>
    /// Singleton applied Classwork Rest Client for Rest Calls
    /// Mostly swagger apis are not manually coded like this, auto rest etc structores provides automatic client code generation
    /// for swagger expose service apis. For this simple example i manually coded the client code for fun
    /// </summary>
    public class ClassworkRestClient : Singleton<ClassworkRestClient>
    {
        /// <summary>
        /// EndPoint Path
        /// </summary>
        private const string _endpointName = "classworks";

        /// <summary>
        /// classworkd/summary POST Api Client Method
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
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
                headerParameters: GetAccessTokenHeader(),
                contentParameter: postContent)
            { IgnoreCertificateErrors = true };

            RestServiceClient client = new RestServiceClient();
            RestServiceCallResponse result = await client.CallRestServiceAsync<String>(parameters);

            var resultObject = JsonConvert.DeserializeObject<List<ClassworkSummary>>(result.ResultObject.ToString());

            return resultObject;
        }

        /// <summary>
        /// classworks POST Api Client Method
        /// </summary>
        /// <param name="qp"></param>
        /// <returns></returns>
        public async Task<List<ClassworkSummary>> GetClassworkSummary(QueryParameter qp)
        {
            RestRequestParameter parameters = new RestRequestParameter(
                ServiceSettings.ServiceAddress.GetRequestUrl($"/api/{_endpointName}?offset={qp.Offset}&limit={qp.Limit}"),
                HttpMethod.Get,
                headerParameters: GetAccessTokenHeader())
            { IgnoreCertificateErrors = true };

            RestServiceClient client = new RestServiceClient();
            RestServiceCallResponse result = await client.CallRestServiceAsync<String>(parameters);

            var resultObject = JsonConvert.DeserializeObject<List<ClassworkSummary>>(result.ResultObject.ToString());

            return resultObject;
        }

        /// <summary>
        /// Dummy auth access token for oauth standard usage
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, List<string>> GetAccessTokenHeader()
        {
            string accessToken = "herthrth65hj56j5j7j57j57j7jtyutj7";
            Dictionary<string, List<string>> authenticationHeaderParams = new Dictionary<string, List<string>>();
            var headerParams = new List<string>();
            headerParams.Add("Bearer " + accessToken);
            authenticationHeaderParams.Add("Authorization", headerParams);
            return authenticationHeaderParams;
        }


    }
}
