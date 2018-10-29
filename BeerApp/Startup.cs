using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BeerApp.Startup))]
namespace BeerApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
