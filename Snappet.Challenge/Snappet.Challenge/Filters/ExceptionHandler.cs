using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace Snappet.Challenge.Filters
{
    public class CustomExceptionHandler:ExceptionHandler
    {
        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            return true;
        }
        public override void Handle(ExceptionHandlerContext context)
        {
            //log excpetion
            var errorInfo = string.Empty;
            context.Result = new ExceptionResult
            {
                Content = "Oops! Something went wrong.",
                Request = context.ExceptionContext.Request
            };
        }

        private class ExceptionResult : IHttpActionResult
        {
            public HttpRequestMessage Request { get; set; }
            public string Content { get; set; }
            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                var response=new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
                {
                    Content= new StringContent(Content),
                    RequestMessage=Request
                };
                return Task.FromResult(response);
            }
        }
    }
}