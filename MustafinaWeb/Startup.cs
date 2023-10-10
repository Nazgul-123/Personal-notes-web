using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MustafinaWeb.Startup))]
namespace MustafinaWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
