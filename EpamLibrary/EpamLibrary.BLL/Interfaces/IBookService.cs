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
        /// <summary>
        /// returs all books with additional filtres
        /// </summary>
        IEnumerable<BookDTO> GetAllBooks(string search = null, DateTime? start = null, DateTime? end = null);
        /// <summary>
        /// returns all authors
        /// </summary>
        IEnumerable<AuthorDTO> GetAllAuthors();
        /// <summary>
        /// returns all selected author books
        /// </summary>
        IEnumerable<BookDTO> GetSpecificAuthorBooks(string name);
        /// <summary>
        /// returns all genres
        /// </summary>
        IEnumerable<GenreDTO> GetAllGenres();
        /// <summary>
        /// returns all books with selected genre
        /// </summary>
        IEnumerable<BookDTO> GetSpecificGenreBooks(string name);
        /// <summary>
        /// returns all publishers
        /// </summary>
        IEnumerable<PublisherDTO> GetAllPublishers();
        /// <summary>
        /// returns all books from selected publisher
        /// </summary>
        IEnumerable<BookDTO> GetSpecificPublisherBooks(string name);
        /// <summary>
        /// creates new book
        /// if book with current name exist in database, it just increases it's quantity
        /// </summary>
        void AddBook(BookDTO bookDTO);
        /// <summary>
        /// edits book
        /// </summary>
        void EditBook(BookDTO bookDTO);
        /// <summary>
        /// returns book by id
        /// </summary>
        BookDTO GetBookById(int id);
    }
}
