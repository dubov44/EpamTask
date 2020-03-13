using EpamLibrary.Tables.Models.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpamLibrary.Tables.Models
{
    public class Author : AbstractDbObject
    {
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public Author()
        {
            Books = new List<Book>();
        }
    }
}
