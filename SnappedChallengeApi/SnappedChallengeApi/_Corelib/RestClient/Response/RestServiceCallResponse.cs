using System;
using System.Net;
using System.Net.Http.Headers;

namespace SnappedChallengeApi._Corelib.RestClient.Response
{
    public class RestServiceCallResponse
    {
        public bool HasSucceeded { get; set; }

        public Exception Error { get; set; }

        public Object ResultObject { get; set; }

        public HttpStatusCode ResponseHttpStatus { get; set; }

        public HttpResponseHeaders ResponseHeaders { get; set; }
        
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
