using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Dashboard.Startup))]
namespace Dashboard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
