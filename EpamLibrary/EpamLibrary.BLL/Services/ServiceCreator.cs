using EpamLibrary.BLL.Interfaces;
using EpamLibrary.DAL.Repositories;

namespace EpamLibrary.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new UnitOfWork(connection));
        }
    }
}