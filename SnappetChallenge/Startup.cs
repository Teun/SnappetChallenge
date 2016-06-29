using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SnappetChallenge.Startup))]
namespace SnappetChallenge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {            
        }
    }
}
