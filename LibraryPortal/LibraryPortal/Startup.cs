using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibraryPortal.Startup))]
namespace LibraryPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // ConfigureAuth(app);
        }
    }
}
