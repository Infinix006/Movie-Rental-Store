using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Movie_Rental_Store.Startup))]
namespace Movie_Rental_Store
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
