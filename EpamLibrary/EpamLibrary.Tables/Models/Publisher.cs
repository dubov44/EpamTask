using EpamLibrary.Tables.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamLibrary.Tables.Models
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
