using System;

namespace SnappedChallengeApi._Corelib.RestClient.Response
{
    /// <summary>
    /// Exception class model for http request response
    /// </summary>
    public class RestServiceException : Exception
    {
        /// <summary>
        /// Status integer code
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Response Error Message
        /// </summary>
        public string ServerErrorMessage { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="serverErrorMessage"></param>
        public RestServiceException(int statusCode, string serverErrorMessage) : base(serverErrorMessage)
        {
            StatusCode = statusCode;
            ServerErrorMessage = serverErrorMessage;
        }
    }
}
