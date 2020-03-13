using EpamLibrary.BLL.Interfaces;
using EpamLibrary.BLL.Services;
using EpamLibrary.DAL.Interfaces;
using EpamLibrary.DAL.Repositories;
using EpamLibrary.Tables.Models;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamLibrary.BLL.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<IServiceCreator>().To<ServiceCreator>();
            Bind<IBookService>().To<BookService>();
            Bind<IRequestService>().To<RequestService>();
            Bind<IRentedBookService>().To<RentedBookService>();
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument("EpamLibrary");
        }
    }
}
