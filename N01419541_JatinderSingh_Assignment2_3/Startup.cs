using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(N01419541_JatinderSingh_Assignment2_3.Startup))]
namespace N01419541_JatinderSingh_Assignment2_3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
