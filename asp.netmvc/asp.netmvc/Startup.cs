using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(asp.netmvc.Startup))]
namespace asp.netmvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}