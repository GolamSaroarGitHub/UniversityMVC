using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmpireUniversity.Startup))]
namespace EmpireUniversity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
