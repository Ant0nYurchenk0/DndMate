using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DndMate.WebApp.Startup))]
namespace DndMate.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
