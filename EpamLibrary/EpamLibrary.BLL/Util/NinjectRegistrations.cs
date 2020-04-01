using EpamLibrary.BLL.Interfaces;
using EpamLibrary.BLL.Services;
using EpamLibrary.DAL.Interfaces;
using EpamLibrary.DAL.Repositories;
using Ninject.Modules;

namespace EpamLibrary.BLL.Util
{
    /// <summary>
    /// makes ninject work
    /// </summary>
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
