using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorkViewer
{
    public class NotFoundComponent : OwinMiddleware
    {
        public NotFoundComponent(OwinMiddleware next)
            :base(next)
        {

        }

        public override async Task Invoke(IOwinContext context)
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("Resource not found");
        }
    }
}
