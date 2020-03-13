using EpamLibrary.DAL.EF;
using EpamLibrary.DAL.Entities;
using EpamLibrary.DAL.Interfaces;
using EpamLibrary.Tables.Models;
using System.Data.Entity;
using System.Linq;

namespace EpamLibrary.DAL.Repositories
{
    public class ClientManager : IClientManager
    {
        public ApplicationContext Database { get; set; }
        public ClientManager(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }
        public void Update(ClientProfile item)
        {
            Database.Entry(item).State = EntityState.Modified;
            Database.SaveChanges();
        }
        public ClientProfile GetById(string id)
        {
            var entity = Database.ClientProfiles.FirstOrDefault(e => e.ClientProfileId == id);

            return entity;
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}