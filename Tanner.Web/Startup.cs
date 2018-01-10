using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tanner.Web.Startup))]
namespace Tanner.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
