using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DogBirthday.Startup))]
namespace DogBirthday
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
