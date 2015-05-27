using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DeployMvcEF.Startup))]
namespace DeployMvcEF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
