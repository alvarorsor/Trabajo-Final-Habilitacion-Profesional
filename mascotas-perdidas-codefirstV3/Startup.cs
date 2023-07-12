using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mascotas_perdidas_codefirstV3.Startup))]
namespace mascotas_perdidas_codefirstV3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            
        }

        
    }
}
