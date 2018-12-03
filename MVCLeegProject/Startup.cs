using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCLeegProject.Startup))]
namespace MVCLeegProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
