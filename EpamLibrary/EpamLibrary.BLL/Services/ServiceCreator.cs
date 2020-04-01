using EpamLibrary.BLL.Interfaces;
using EpamLibrary.DAL.Repositories;

namespace EpamLibrary.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        /// <summary>
        /// creates user service
        /// </summary>
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new UnitOfWork(connection));
        }
    }
}