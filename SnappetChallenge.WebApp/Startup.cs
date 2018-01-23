using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SnappetChallenge.WebApp.Startup))]
namespace SnappetChallenge.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
