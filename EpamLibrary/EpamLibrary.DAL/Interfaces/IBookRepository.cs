using EpamLibrary.Tables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamLibrary.DAL.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Book GetByName(string name);
        List<Author> GetAuthor();
        void CreateBook(Book item);
        void UpdateBook(Book item);
    }
}
