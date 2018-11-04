using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SnappedChallengeApi._Corelib.RestClient.Request
{
    public class RestRequestParameter
    {
        public string RequestURL { get; set; }

        public HttpMethod HttpMethod { get; set; }

        public Dictionary<string, List<string>> URLParameters { get; set; }

        public HttpContent RequestContent { get; set; }

        public string ErrorResultTagId { get; set; }

        public Dictionary<string, List<string>> HeaderParameters { get; set; }

        public TimeSpan RequestTimeOut = new TimeSpan(0, 5, 0);

        public bool IgnoreCertificateErrors { get; set; }

        public List<HttpStatusCode> SuccessStatusCodes = new List<HttpStatusCode>() { HttpStatusCode.OK, HttpStatusCode.Created };

        public List<X509Certificate> ClientCertificates { get; set; }

        public RestRequestParameter(string requestURL,
                                    HttpMethod httpMethod,
                                    Dictionary<string, List<string>> urlParameters = null,
                                    HttpContent contentParameter = null,
                                    string errorMessageTagId = "message",
                                    Dictionary<string, List<string>> headerParameters = null,
                                    bool ignoreCertificateErrors = false,
                                    List<HttpStatusCode> successStatusCodes = null
                                    )
        {
            RequestURL = requestURL;
            HttpMethod = httpMethod;
            URLParameters = urlParameters;
            RequestContent = contentParameter;
            ErrorResultTagId = errorMessageTagId;
            HeaderParameters = headerParameters;
            IgnoreCertificateErrors = ignoreCertificateErrors;

            if (successStatusCodes != null && successStatusCodes.Any())
            {
                SuccessStatusCodes = successStatusCodes;
            }
        }


        public Uri GetRequestUri()
        {
            StringBuilder URLContent = new StringBuilder();
            URLContent.Append(RequestURL);

            if (URLParameters != null && URLParameters.Count > 0)
            {
                // son parametre tanimlanir
                string lastParameter = Enumerable.Last<string>((IEnumerable<string>)URLParameters);

                URLContent.Append("?");
                foreach (string index in URLParameters.Keys)
                {
                    URLContent.Append(index);
                    URLContent.Append("=");
                    string queryString = Uri.EscapeDataString(string.Join(",", URLParameters[index]));
                    URLContent.Append(queryString);
                    if (!lastParameter.Equals(index))
                        URLContent.Append("&");
                }
            }
            return new Uri(URLContent.ToString());
        }



    }
}
