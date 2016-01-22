using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PageWizardPoc.Startup))]
namespace PageWizardPoc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
