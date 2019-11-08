using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FestivalSales.Startup))]
namespace FestivalSales
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
