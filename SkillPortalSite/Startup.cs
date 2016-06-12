using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SkillPortalSite.Startup))]
namespace SkillPortalSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
