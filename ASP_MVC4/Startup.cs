using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASP_MVC4.Startup))]
namespace ASP_MVC4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
