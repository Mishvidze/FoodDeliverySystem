using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FoodDeliverySystem.Startup))]
namespace FoodDeliverySystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
