using System;
using System.Net;
using System.Net.Http.Headers;

namespace SnappedChallengeApi._Corelib.RestClient.Response
{
    /// <summary>
    /// Response Data model class
    /// </summary>
    public class RestServiceCallResponse
    {
        /// <summary>
        /// Flag if response is failed or not
        /// </summary>
        public bool HasSucceeded { get; set; }

        /// <summary>
        /// Response Exception for the error if needed
        /// </summary>
        public Exception Error { get; set; }

        /// <summary>
        /// Response Object
        /// </summary>
        public Object ResultObject { get; set; }

        /// <summary>
        /// Response status code
        /// </summary>
        public HttpStatusCode ResponseHttpStatus { get; set; }

        /// <summary>
        /// Response header of the request
        /// </summary>
        public HttpResponseHeaders ResponseHeaders { get; set; }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="resultObject"></param>
        /// <param name="hasSucceeded"></param>
        /// <param name="error"></param>
        /// <param name="responseStatusCode"></param>
        /// <param name="reponseHeader"></param>
        public RestServiceCallResponse(Object resultObject, 
                                        bool hasSucceeded, 
                                        Exception error, 
                                        HttpStatusCode responseStatusCode, 
                                        HttpResponseHeaders reponseHeader)
        {
           ResultObject = resultObject;
           Error = error;
           HasSucceeded = hasSucceeded;
           ResponseHttpStatus = responseStatusCode;
           ResponseHeaders = reponseHeader;
        }
    }
}
