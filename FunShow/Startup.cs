using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FunShow.Startup))]
namespace FunShow
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
