using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SnappedChallengeApi._Corelib.RestClient.Request
{
    /// <summary>
    /// 
    /// </summary>
    public class RestRequestParameter
    {
        /// <summary>
        /// Request url
        /// </summary>
        public string RequestURL { get; set; }
        /// <summary>
        /// http method get, put,post,delete etc.
        /// </summary>
        public HttpMethod HttpMethod { get; set; }
        /// <summary>
        /// Url Parameters
        /// </summary>
        public Dictionary<string, List<string>> URLParameters { get; set; }
        /// <summary>
        /// Request http body content string, form content etc.
        /// </summary>
        public HttpContent RequestContent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ErrorResultTagId { get; set; }
        /// <summary>
        /// If error result defined specific it can be filled for response parse operations
        /// </summary>
        public Dictionary<string, List<string>> HeaderParameters { get; set; }
        /// <summary>
        /// Default http client timeout duration, can be changed if needed
        /// </summary>
        public TimeSpan RequestTimeOut = new TimeSpan(0, 5, 0);
        /// <summary>
        /// If ssl sertificates are invalid or expired set this to true if it is needed to be ignored
        /// </summary>
        public bool IgnoreCertificateErrors { get; set; }
        /// <summary>
        /// Default http response codes that defines the sucess of the request
        /// </summary>
        public List<HttpStatusCode> SuccessStatusCodes = new List<HttpStatusCode>() { HttpStatusCode.OK, HttpStatusCode.Created };
        /// <summary>
        /// Certificates if needed for the call
        /// </summary>
        public List<X509Certificate> ClientCertificates { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestURL"></param>
        /// <param name="httpMethod"></param>
        /// <param name="urlParameters"></param>
        /// <param name="contentParameter"></param>
        /// <param name="errorMessageTagId"></param>
        /// <param name="headerParameters"></param>
        /// <param name="ignoreCertificateErrors"></param>
        /// <param name="successStatusCodes"></param>
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

        /// <summary>
        /// Request Url
        /// </summary>
        /// <returns></returns>
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
