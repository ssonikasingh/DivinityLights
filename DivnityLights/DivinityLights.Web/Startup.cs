using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DivinityLights.Web.Startup))]
namespace DivinityLights.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
