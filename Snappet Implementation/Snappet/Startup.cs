using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Snappet.Startup))]
namespace Snappet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
