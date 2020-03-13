using EpamLibrary.DAL.EF;
using EpamLibrary.DAL.Interfaces;
using EpamLibrary.DAL.Repositories;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamLibrary.Infrastructure.DependencyResolution
{
    public class NinjectDalModule : NinjectModule
    {
        private readonly string _efConnectionString;

        public NinjectDalModule(string efConnectionString)
        {
            _efConnectionString = efConnectionString;
        }

        public override void Load()
        {
            Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));

            //Bind<ApplicationContext>().ToSelf().InRequestScope()
                //.WithConstructorArgument(_efConnectionString);

            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
