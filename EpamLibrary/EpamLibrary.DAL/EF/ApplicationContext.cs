using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using EpamLibrary.DAL.Entities;
using EpamLibrary.Tables.Models;

namespace EpamLibrary.DAL.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string conectionString) : base(conectionString) { }
        public ApplicationContext() : base("DefaultConnection") { }
        static ApplicationContext()
        {
            Database.SetInitializer(new DbInitializer());
        }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<RentedBook> RentedBooks { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}