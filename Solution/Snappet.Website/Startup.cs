using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Snappet.Website.Startup))]
namespace Snappet.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
