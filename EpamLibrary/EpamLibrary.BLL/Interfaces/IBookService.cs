using EpamLibrary.BLL.DTO;
using System;
using System.Collections.Generic;

namespace EpamLibrary.BLL.Interfaces
{
    /// <summary>
    /// operations with books
    /// </summary>
    public interface IBookService
    {
        IEnumerable<BookDTO> GetAllBooks(string search = null, DateTime? start = null, DateTime? end = null);
        IEnumerable<AuthorDTO> GetAllAuthors();
        IEnumerable<BookDTO> GetSpecificAuthorBooks(string name);
        IEnumerable<GenreDTO> GetAllGenres();
        IEnumerable<BookDTO> GetSpecificGenreBooks(string name);
        IEnumerable<PublisherDTO> GetAllPublishers();
        IEnumerable<BookDTO> GetSpecificPublisherBooks(string name);
        void AddBook(BookDTO bookDTO);
        void EditBook(BookDTO bookDTO);
        BookDTO GetBookById(int id);
    }
}
