using System;

namespace SnappetChallenge
{
    public class HttpResponseException : Exception
    {
        public int HttpCode { get; }

        public HttpResponseException(string message, int httpCode): base(message)
        {
            HttpCode = httpCode;
        }
    }
}