using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyAssignment2.Startup))]
namespace MyAssignment2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
