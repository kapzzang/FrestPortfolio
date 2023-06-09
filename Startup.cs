using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(proTnsWeb.Startup))]
namespace proTnsWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
