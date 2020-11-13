using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MusicalInstrument.Startup))]
namespace MusicalInstrument
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
