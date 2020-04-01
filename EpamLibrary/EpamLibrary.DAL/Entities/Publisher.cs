using EpamLibrary.DAL.Entities.Abstract;
using System.Collections.Generic;

namespace EpamLibrary.DAL.Entities
{
    public class Publisher : AbstractDbObject
    {
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public Publisher()
        {
            Books = new List<Book>();
        }
    }
}
