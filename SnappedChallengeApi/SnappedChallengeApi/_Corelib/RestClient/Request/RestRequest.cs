﻿using SnappedChallengeApi._Corelib.RestClient.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SnappedChallengeApi._Corelib.RestClient.Request
{
    public class RestRequest
    {
        public async Task<HttpResponseMessage> SendRequestAsync(RestRequestParameter restRequestParameter)
        {
            HttpResponseMessage response;

            Uri url = restRequestParameter.GetRequestUri();

            if (restRequestParameter.IgnoreCertificateErrors)
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => { return true; };
            }

            using (HttpClient httpClient = CreateHttpClient(restRequestParameter.RequestTimeOut, restRequestParameter.ClientCertificates))
            {
                HttpRequestMessage httpRequestMessage = null;
                try
                {
                    httpRequestMessage = new HttpRequestMessage(restRequestParameter.HttpMethod, url)
                    {
                        Content = restRequestParameter.RequestContent
                    };

                    if (restRequestParameter.HeaderParameters != null)
                    {
                        foreach (var headerDefinition in restRequestParameter.HeaderParameters.Keys)
                        {
                            httpRequestMessage.Headers.Add(headerDefinition, restRequestParameter.HeaderParameters[headerDefinition]);
                        }
                    }

                    response = await httpClient.SendAsync(httpRequestMessage);
                }
                catch (Exception ex)
                {
                    Exception sourceException = ex;
                    if (ex.InnerException != null)
                    {
                        sourceException = ex.InnerException;
                    }

                    RestResponseMessage restReponseMessage = new RestResponseMessage(HttpStatusCode.BadRequest, sourceException) { RequestMessage = httpRequestMessage };

                    response = restReponseMessage;
                }
            }
            return response;
        }

        private HttpClient CreateHttpClient(TimeSpan requestTimeOut, List<X509Certificate> clientCertificates = null)
        {
            HttpClientHandler handler = new HttpClientHandler();
            if (clientCertificates != null && clientCertificates.Any())
            {

                foreach (var clientCertificate in clientCertificates)
                {
                    handler.ClientCertificates.Add((X509Certificate)clientCertificate);
                }
            }

            return new HttpClient(handler)
            {
                DefaultRequestHeaders =
                {
                    Accept = {
                            new MediaTypeWithQualityHeaderValue("application/json"),
                            new MediaTypeWithQualityHeaderValue("application/octet-stream")
                            }
                },
                Timeout = requestTimeOut
            };
        }
    }
}