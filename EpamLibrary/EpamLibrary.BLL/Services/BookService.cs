using EpamLibrary.BLL.DTO;
using EpamLibrary.BLL.Infrastructure.Mappers;
using EpamLibrary.BLL.Interfaces;
using EpamLibrary.DAL.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EpamLibrary.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        Logger log = LogManager.GetCurrentClassLogger();

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// returs all books with additional filtres
        /// </summary>
        public IEnumerable<BookDTO> GetAllBooks(string search = null, DateTime? start = null, DateTime? end = null)
        {
            var books = _unitOfWork.BookRepository.Get().OrderByDescending(b => b.Id).ToList();
            if (search != null)
            {
                books = _unitOfWork.BookRepository.Get(b => b.Name.Contains(search)).OrderByDescending(b => b.Id).ToList();
                if(books.Count == 0)
                {
                    var authors = _unitOfWork.AuthorRepository.Get(a => a.Name.Contains(search)).OrderByDescending(a => a.Id);
                    foreach (var author in authors)
                    {
                        books.AddRange(author.Books.ToList());
                    }
                }
                if (books.Count == 0)
                {
                    books = _unitOfWork.BookRepository.Get(b => b.Publisher.Name.Contains(search)).OrderByDescending(b => b.Id).ToList();
                }
            }
            if(start != null)
            {
                books = books.Where(a => a.PublicationDate > start).ToList();
            }
            if (end != null)
            {
                books = books.Where(a => a.PublicationDate < end).ToList();
            }
            return books.ToDTO();
        }

        /// <summary>
        /// returns book by id
        /// </summary>
        public BookDTO GetBookById(int id)
        {
            return _unitOfWork.BookRepository.GetById(id).ToDTO();
        }

        /// <summary>
        /// returns all authors
        /// </summary>
        public IEnumerable<AuthorDTO> GetAllAuthors()
        {
            return _unitOfWork.AuthorRepository.Get().OrderBy(b => b.Name).ToDTO();
        }

        /// <summary>
        /// returns author by name
        /// </summary>
        public IEnumerable<BookDTO> GetSpecificAuthorBooks(string name)
        {
            return _unitOfWork.AuthorRepository.Get(a => a.Name == name).Single().Books.ToDTO();
        }

        /// <summary>
        /// returns all publishers
        /// </summary>
        public IEnumerable<PublisherDTO> GetAllPublishers()
        {
            return _unitOfWork.PublisherRepository.Get().OrderBy(b => b.Name).ToDTO();
        }

        /// <summary>
        /// returns all books from selected publisher
        /// </summary>
        public IEnumerable<BookDTO> GetSpecificPublisherBooks(string name)
        {
            return _unitOfWork.PublisherRepository.Get(a => a.Name == name).Single().Books.ToDTO();
        }

        /// <summary>
        /// returns all genres
        /// </summary>
        public IEnumerable<GenreDTO> GetAllGenres()
        {
            return _unitOfWork.GenreRepository.Get().OrderBy(b => b.Name).ToDTO();
        }

        /// <summary>
        /// returns all books with selected genre
        /// </summary>
        public IEnumerable<BookDTO> GetSpecificGenreBooks(string name)
        {
            return _unitOfWork.GenreRepository.Get(a => a.Name == name).Single().Books.ToDTO();
        }

        /// <summary>
        /// creates new book
        /// if book with current name exist in database, it just increases it's quantity
        /// </summary>
        public void AddBook(BookDTO bookDTO)
        {
            if (_unitOfWork.BookRepository.GetByName(bookDTO.Name) == null)
            {
                _unitOfWork.BookRepository.CreateBook(bookDTO.ToEntity());
                log.Info($"book {bookDTO.Name} was created");
            }
            else
            {
                var _tempBook = _unitOfWork.BookRepository.GetByName(bookDTO.Name);
                _tempBook.Quantity += bookDTO.Quantity;
                _unitOfWork.BookRepository.Update(_tempBook);
            }
            _unitOfWork.Save();
        }

        /// <summary>
        /// edits book
        /// </summary>
        public void EditBook(BookDTO bookDTO)
        {
            _unitOfWork.BookRepository.UpdateBook(bookDTO.ToEntity());
            log.Info($"book {bookDTO.Name} was edited");
        }
    }
}
