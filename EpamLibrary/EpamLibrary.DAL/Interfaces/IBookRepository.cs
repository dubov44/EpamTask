using EpamLibrary.DAL.Entities;
using System.Collections.Generic;

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
