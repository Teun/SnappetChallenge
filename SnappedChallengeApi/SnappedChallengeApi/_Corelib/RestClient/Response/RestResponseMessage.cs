using System;
using System.Net;
using System.Net.Http;

namespace SnappedChallengeApi._Corelib.RestClient.Response
{
    /// <summary>
    /// 
    /// </summary>
    public class RestResponseMessage : HttpResponseMessage
    {
        /// <summary>
        /// Exception if needed for the response error
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="exception"></param>
        public RestResponseMessage(Exception exception)
        {
            Exception = exception;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="exception"></param>
        public RestResponseMessage(HttpStatusCode statusCode, Exception exception) : base(statusCode)
        {
            Exception = exception;
        }
    }
}
