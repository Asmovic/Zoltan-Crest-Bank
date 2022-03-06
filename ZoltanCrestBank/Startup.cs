using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZoltanCrestBank.Startup))]
namespace ZoltanCrestBank
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
