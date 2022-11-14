using SnappetChallenge.Client.Model;
using SnappetChallenge.Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using SnappentChallengeExceptions = SnappetChallenge.Client.Exceptions;
using SnappentChallengeJsonSerializer = SnappetChallenge.Client.Utilities;

namespace SnappetChallenge.Client.Service
{
    public class HttpService 
    {
        #region Field
        private static HttpClient _httpClient;
        private HttpClient HttpClient
        {
            get
            {
                if (_httpClient == null)
                {
                    _httpClient = new HttpClient();
                    _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }
                return _httpClient;
            }
        }
        #endregion

        #region Constructor
        public HttpService()
        {
        }

        #endregion

        #region Public methods
        public async Task GetRequest(string relativeUrl)
        {
            var headers = createHeaders();

            await PerformRequest(HttpMethod.Get, relativeUrl, headers, null);
        }

        public async Task<T> GetRequest<T>(string relativeUrl)
        {
            var headers = createHeaders();

            return await PerformRequest<T>(HttpMethod.Get, relativeUrl, headers, null);
        }

        public async Task PostRequest(string relativeUrl, object content)
        {
            var headers =  createHeaders();
            var httpContent = BuildHttpContent(content);

            await PerformRequest(HttpMethod.Post, relativeUrl, headers, httpContent);
        }

        public async Task<T> PostRequest<T>(string relativeUrl)
        {
            return await PostRequest<T>(relativeUrl, null);
        }

        public async Task<T> PostRequest<T>(string relativeUrl, object content)
        {
            var headers = createHeaders();
            var httpContent = BuildHttpContent(content);

            return await PerformRequest<T>(HttpMethod.Post, relativeUrl, headers, httpContent);
        }

        #endregion

        #region Private methods - Perform Request
        private async Task PerformRequest(HttpMethod httpMethod, string relativeUrl, Dictionary<string, string> headers, HttpContent content, int retryNumber = 0)
        {
            var request = createRequestMessage(httpMethod, relativeUrl, headers, content);
            var response = await HttpClient.SendAsync(request);

            if (response?.StatusCode == HttpStatusCode.OK)
            {
                return;
            }
            else
            {
                var isServerException = response?.StatusCode == HttpStatusCode.BadRequest || response?.StatusCode == HttpStatusCode.InternalServerError;
                var needsRetry = !isServerException && retryNumber <= 2;

                if (needsRetry)
                    await PerformRequest(httpMethod, relativeUrl, headers, content, retryNumber + 1);
                else
                {
                    var responseString = await response.Content?.ReadAsStringAsync();
                    ReturnErrorMessage(response, responseString);
                }
            }
        }

        private void ReturnErrorMessage(HttpResponseMessage response, string responseString)
        {
            var isBreakingHttpException = response?.StatusCode != null
                ? response.StatusCode == HttpStatusCode.Unauthorized
                    || response.StatusCode == HttpStatusCode.Forbidden
                    || response.StatusCode == HttpStatusCode.GatewayTimeout
                    || response.StatusCode == HttpStatusCode.ServiceUnavailable
                    || response.StatusCode == HttpStatusCode.BadGateway
                    || response.StatusCode == HttpStatusCode.RequestTimeout
                    || ((int)response.StatusCode) == 0
                    || ((int)response.StatusCode) == -1
                : false;

            if (isBreakingHttpException)
            {
               // throw new RequestFailedException();
            }
            else
            {
             

              //  throw new RequestException(errorMessage);
            }
        }

        private async Task<T> PerformRequest<T>(HttpMethod httpMethod, string relativeUrl, Dictionary<string, string> headers, HttpContent content,int retryNumber = 0)
        {
            var request = createRequestMessage(httpMethod, relativeUrl, headers, content);
            var response = await HttpClient.SendAsync(request);
            var responseString = await response.Content?.ReadAsStringAsync();

            if (response?.StatusCode == HttpStatusCode.OK)
            {
                if (!string.IsNullOrEmpty(responseString))
                {
                    var resultWrapper = SnappentChallengeJsonSerializer.JsonSerializer.Deserialize<JsonWrapper<T>>(responseString);
                    if (!resultWrapper.Success)
                    {
                        throw new Exception(resultWrapper.ErrorMessage);
                    }
                    return resultWrapper.Content;
                }
                else
                {
                    return default(T);
                }
            }
            else
            {
                var isServerException = response?.StatusCode == HttpStatusCode.BadRequest || response?.StatusCode == HttpStatusCode.InternalServerError;
                var needsRetry = !isServerException && retryNumber <= 2;

                if (needsRetry)
                {
                    return await PerformRequest<T>(httpMethod, relativeUrl, headers, content, retryNumber + 1);
                }
                else
                {
                    var isBreakingHttpException = response?.StatusCode != null
                        ? response.StatusCode == HttpStatusCode.Unauthorized
                            || response.StatusCode == HttpStatusCode.Forbidden
                            || response.StatusCode == HttpStatusCode.GatewayTimeout
                            || response.StatusCode == HttpStatusCode.ServiceUnavailable
                            || response.StatusCode == HttpStatusCode.BadGateway
                            || response.StatusCode == HttpStatusCode.RequestTimeout
                            || ((int)response.StatusCode) == 0
                            || ((int)response.StatusCode) == -1
                        : false;

                    if (isBreakingHttpException)
                    {
                        throw new SnappentChallengeExceptions.RequestFailedException();
                    }
                    else
                    {
                        throw new SnappentChallengeExceptions.RequestException();
                    }
                }

            }
        }
        #endregion

        #region Private methods - Helper methods
        private Dictionary<string, string> createHeaders()
        {
            var headers = new Dictionary<string, string>();

            headers.Add("Accept-Language", "en");
            headers.Add("Accept", "application/json");
            return headers;
        }

        private HttpRequestMessage createRequestMessage(HttpMethod httpMethod, string relativeUrl, Dictionary<string, string> headers, HttpContent content)
        {
            var uri = new Uri(new Uri(SnappentSetting.snappentSetting.CurrentEnvironment), relativeUrl);

            var request = new HttpRequestMessage(httpMethod, uri);
            request.Content = content;

            foreach (var header in headers)
                request.Headers.Add(header.Key, header.Value);

            return request;
        }

        private StringContent BuildHttpContent(object content)
        {
            if (content != null)
            {
                var stringContent = SnappetChallenge.Client.Utilities.JsonSerializer.Serialize(content);
                var httpContent = new StringContent(stringContent);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return httpContent;
            }
            return null;
        }
        #endregion
    }

}
