using EpamLibrary.DAL.EF;
using EpamLibrary.DAL.Entities;
using EpamLibrary.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;
using EpamLibrary.DAL.Identity;
using EpamLibrary.Tables.Models;
using System.Data.Common;

namespace EpamLibrary.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _dbContext;

        public UnitOfWork(string connectionString)
        {
            _dbContext = new ApplicationContext(connectionString);
        }
        public ApplicationUserManager UserManager => new ApplicationUserManager(new UserStore<ApplicationUser>(_dbContext));
        public ApplicationRoleManager RoleManager => new ApplicationRoleManager(new RoleStore<ApplicationRole>(_dbContext));
        public IClientManager ClientManager => new ClientManager(_dbContext);
        public IRepository<Author> AuthorRepository => new GenericRepository<Author>(_dbContext);
        public IBookRepository BookRepository => new BookRepository(_dbContext);
        public IRepository<Genre> GenreRepository => new GenericRepository<Genre>(_dbContext);
        public IRepository<Request> RequestRepository => new GenericRepository<Request>(_dbContext);
        public IRepository<RentedBook> RentedBookRepository => new GenericRepository<RentedBook>(_dbContext);
        public IRepository<Publisher> PublisherRepository => new GenericRepository<Publisher>(_dbContext);

        public void Save()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbException ex)
            {
                //logger.log(ex.)
            }
            
        }
        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    UserManager.Dispose();
                    RoleManager.Dispose();
                    ClientManager.Dispose();
                    AuthorRepository.Dispose();
                    BookRepository.Dispose();
                    GenreRepository.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}