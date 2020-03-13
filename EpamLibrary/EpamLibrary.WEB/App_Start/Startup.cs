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

            //app.UseNinjectMiddleware(CreateKernel);
        }

        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService("DefaultConnection");
        }
        //private static StandardKernel CreateKernel()
        //{
        //    var kernel = new StandardKernel(new NinjectRegistrations());

        //    kernel.Bind<IUserService>().To<UserService>();
        //    kernel.Bind<IBookService>().To<BookService>();

        //    return kernel;
        //}
    }
    ////IServiceCreator serviceCreator = new ServiceCreator();
    //public void Configuration(IAppBuilder app)
    //    {
    //        //app.CreatePerOwinContext<IUserService>(CreateUserService);
    //        app.UseCookieAuthentication(new CookieAuthenticationOptions
    //        {
    //            AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
    //            LoginPath = new PathString("/Account/Login"),
    //        });

    //        //app.UseNinjectMiddleware(CreateKernel);
    //    }

    //    //private IUserService CreateUserService()
    //    //{
    //    //    return serviceCreator.CreateUserService("DefaultConnection");
    //    //}
    //    //private static StandardKernel CreateKernel()
    //    //{
    //    //    var kernel = new StandardKernel(new UnitOfWorkModule());

    //    //    kernel.Bind<IUserService>().To<UserService>();
    //    //    kernel.Bind<IServiceCreator>().To<ServiceCreator>();
    //    //    kernel.Bind<IBookService>().To<BookService>();

    //    //    return kernel;
    //    //}
    //}
}