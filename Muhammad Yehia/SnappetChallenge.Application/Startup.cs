using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SnappetChallenge.Application.Startup))]
namespace SnappetChallenge.Application
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // ConfigureAuth(app);
        }
    }
}
