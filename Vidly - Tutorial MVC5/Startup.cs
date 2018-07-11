using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidly___Tutorial_MVC5.Startup))]
namespace Vidly___Tutorial_MVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
