using EpamLibrary.DAL.Entities;
using EpamLibrary.DAL.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace EpamLibrary.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }
        IClientManager ClientManager { get; }
        IRepository<Author> AuthorRepository { get; }
        IBookRepository BookRepository { get; }
        IRepository<Genre> GenreRepository { get; }
        IRepository<Request> RequestRepository { get; }
        IRepository<RentedBook> RentedBookRepository { get; }
        IRepository<Publisher> PublisherRepository { get; }
        void Save();
        Task SaveAsync();
    }
}
