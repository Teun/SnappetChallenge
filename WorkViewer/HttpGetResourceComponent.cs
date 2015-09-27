using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WorkViewer
{
    public class HttpGetResourceComponent : OwinMiddleware
    {
        public HttpGetResourceComponent(OwinMiddleware next)
            : base(next)
        {
        }

        private Dictionary<string, RequestContentType> contentTypeDictionary = new Dictionary<string,RequestContentType>{
            {  "js", new RequestContentType { Extension = "js", ContentType = "text/javascript"  } },
            {  "html", new RequestContentType { Extension = "html", ContentType = "text/html"  } }
        };
        public override async Task Invoke(IOwinContext context)
        {
            RequestContentType requestContentType = GetContentType(context.Request.Path.Value);
            if(requestContentType != null)
            {
                context.Response.ContentType = requestContentType.ContentType;
                string filePath = MapPath(context.Request.Path.Value);
                if (File.Exists(filePath))
                {
                    using (var contentStream = new FileStream(filePath, FileMode.Open))
                    {
                        await contentStream.CopyToAsync(context.Response.Body);
                    }
                }
                else
                {
                    await Next.Invoke(context);
                }
            }
            else
            {
                await Next.Invoke(context);
            }
        }

        private RequestContentType GetContentType(string appPath)
        {
            string[] segments = appPath.Split('.');
            RequestContentType contentType;
            return segments.Length > 1 && contentTypeDictionary.TryGetValue(segments[segments.Length - 1].ToLowerInvariant(), out contentType) ? contentType : null;
        }

        private string MapPath(string appPath)
        {
            return "." + appPath.Replace('/', System.IO.Path.DirectorySeparatorChar);
        }
    }
}
