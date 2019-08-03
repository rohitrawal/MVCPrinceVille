using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrinceVille.Startup))]
namespace PrinceVille
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
