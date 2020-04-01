using EpamLibrary.DAL.Entities.Abstract;
using System;

namespace EpamLibrary.DAL.Entities
{
    public class RentedBook : AbstractDbObject
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string ClientProfileId { get; set; }
        public virtual ClientProfile ClientProfile { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int Penalty { get; set; }
        public bool IsExpired { get; set; } = false;
        public bool ReadingRoom { get; set; } = false;
    }
}
