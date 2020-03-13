using EpamLibrary.BLL.Interfaces;
using EpamLibrary.BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamLibrary.Infrastructure.DependencyResolution
{
    public class NinjectBllModule : NinjectModule
    {
        public NinjectBllModule()
        {

        }

        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<IServiceCreator>().To<ServiceCreator>();
            Bind<IBookService>().To<BookService>();
        }
    }
}
