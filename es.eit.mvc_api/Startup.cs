using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(es.eit.mvc_api.Startup))]
namespace es.eit.mvc_api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
