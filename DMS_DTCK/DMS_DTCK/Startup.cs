using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DMS_DTCK.Startup))]
namespace DMS_DTCK
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
