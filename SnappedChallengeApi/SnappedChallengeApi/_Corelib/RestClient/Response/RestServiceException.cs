using System;

namespace SnappedChallengeApi._Corelib.RestClient.Response
{
    class RestServiceException : Exception
    {
        public int StatusCode { get; set; }

        public string ServerErrorMessage { get; set; }

        public RestServiceException(int statusCode, string serverErrorMessage) : base(serverErrorMessage)
        {
            StatusCode = statusCode;
            ServerErrorMessage = serverErrorMessage;
        }
    }
}
