using System;
using System.Net;
using System.Net.Http;

namespace SnappedChallengeApi._Corelib.RestClient.Response
{
    public class RestResponseMessage : HttpResponseMessage
    {
        public Exception Exception { get; set; }

        public RestResponseMessage(Exception exception)
        {
            Exception = exception;
        }

        public RestResponseMessage(HttpStatusCode statusCode, Exception exception) : base(statusCode)
        {
            Exception = exception;
        }
    }
}
