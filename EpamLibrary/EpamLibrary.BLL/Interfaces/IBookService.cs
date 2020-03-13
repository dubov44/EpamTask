using EpamLibrary.BLL.DTO;
using EpamLibrary.Tables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamLibrary.BLL.Interfaces
{
    public interface IBookService //: IDisposable
    {
        IEnumerable<BookDTO> GetAllBooks(string search = null, DateTime? start = null, DateTime? end = null);
        IEnumerable<AuthorDTO> GetAllAuthors();
        IEnumerable<BookDTO> GetSpecificAuthorBooks(string name);
        IEnumerable<PublisherDTO> GetAllPublishers();
        IEnumerable<BookDTO> GetSpecificPublisherBooks(string name);
        void AddBook(BookDTO bookDTO);
        void EditBook(BookDTO bookDTO);
        BookDTO GetBookById(int id);
    }
}
