using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using EpamLibrary.BLL.Services;
using Microsoft.AspNet.Identity;
using EpamLibrary.BLL.Interfaces;
using Ninject;
using Ninject.Web.Common.OwinHost;
using EpamLibrary.BLL.Util;

[assembly: OwinStartup(typeof(EpamLibrary.App_Start.Startup))]

namespace EpamLibrary.App_Start
{
    public class Startup
    {
        IServiceCreator serviceCreator = new ServiceCreator();
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IUserService>(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService("DefaultConnection");
        }
    }
}