using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WalkUpAdvertisingShellWeb.Startup))]
namespace WalkUpAdvertisingShellWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
