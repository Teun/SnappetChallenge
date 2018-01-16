using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(Snappet.WebAPI.Startup))]

namespace Snappet.WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}