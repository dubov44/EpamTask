using EpamLibrary.DAL.Entities.Abstract;

namespace EpamLibrary.DAL.Entities
{
    public class Request : AbstractDbObject
    {
        public string ClientName { get; set; }
        public string BookName { get; set; }
        public string ClientProfileId { get; set; }
        public virtual ClientProfile ClientProfile { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
