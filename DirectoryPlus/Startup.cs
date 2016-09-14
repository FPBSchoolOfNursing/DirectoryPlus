using Owin;
using Microsoft.Owin;
[assembly: OwinStartup(typeof(DirectoryPlus.Startup))]

namespace DirectoryPlus
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}