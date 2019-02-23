using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcBlog.WebUI.Startup))]
namespace MvcBlog.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
