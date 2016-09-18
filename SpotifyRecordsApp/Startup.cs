using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpotifyRecordsApp.Startup))]
namespace SpotifyRecordsApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
