using SnappedChallengeApi._Corelib.RestClient.Request;
using SnappedChallengeApi._Corelib.RestClient.Response;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace SnappedChallengeApi._Corelib.RestClient
{
    /// <summary>
    /// Wrapper facade for rest request, this client model encapsulates rest request instance
    /// </summary>
    public class RestServiceClient
    {
        /// <summary>
        /// inner rest request main instance
        /// </summary>
        private RestRequest _restRequest = null;

        /// <summary>
        /// Generic http rest call method with all parameters supplied
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="restRequestParameter"></param>
        /// <returns></returns>
        public async Task<RestServiceCallResponse> CallRestServiceAsync<T>(RestRequestParameter restRequestParameter)
        {
            RestServiceCallResponse result = null;

            _restRequest = new RestRequest();
            HttpResponseMessage response = await _restRequest.SendRequestAsync(restRequestParameter);

            if (restRequestParameter.SuccessStatusCodes.Contains(response.StatusCode))
            {
                try
                {
                    Object resultContent;

                    if (typeof(T) == typeof(Stream))
                    {
                        resultContent = await response.Content.ReadAsStreamAsync();

                    }
                    else if (typeof(T) == typeof(String))
                    {
                        resultContent = await response.Content.ReadAsStringAsync();
                    }
                    else if (typeof(T) == typeof(byte[]))
                    {
                        resultContent = await response.Content.ReadAsByteArrayAsync();
                    }
                    else
                    {
                        throw new Exception("This type is not supported");
                    }

                    result = new RestServiceCallResponse(resultContent, true, null, response.StatusCode, response.Headers);
                }
                catch (Exception ex)
                {
                    result = new RestServiceCallResponse(null, false, ex, response.StatusCode, response.Headers);
                }
            }
            else
            {
                result = new RestServiceCallResponse(null, false, await ParseResponseErrorMessageContent(response), response.StatusCode, response.Headers);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private async Task<Exception> ParseResponseErrorMessageContent(HttpResponseMessage response)
        {
            Exception exceptionResult;
            RestResponseMessage responseMessage = response as RestResponseMessage;

            if (responseMessage != null)
            {
                exceptionResult = responseMessage.Exception;
            }
            else
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                exceptionResult = new RestServiceException((int)response.StatusCode, errorMessage);
            }

            return exceptionResult;
        }


    }
}
