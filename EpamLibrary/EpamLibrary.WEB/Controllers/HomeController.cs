using EpamLibrary.BLL.Interfaces;
using EpamLibrary.Tables.Models;
using EpamLibrary.WEB.Infrastructure.Automapper;
using EpamLibrary.WEB.Models;
using EpamLibrary.WEB.Models.AuthorVM;
using EpamLibrary.WEB.Models.BookVM;
using EpamLibrary.WEB.Models.PublisherVM;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpamLibrary.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IRentedBookService _rentedBookService;
        public HomeController(IBookService bookService, 
            IRentedBookService rentedBookService)
        {
            _bookService = bookService;
            _rentedBookService = rentedBookService;
        }
        public ActionResult Index(string search = null, DateTime? start = null, DateTime? end = null)
        {
            var books = new BookDisplayViewModel()
            {
                Books = _bookService.GetAllBooks(search, start, end).ToDisplayVM()
            };
            return View(books);
        }
        public ActionResult Authors()
        {
            var books = new AuthorDisplayViewModel()
            {
                Authors = _bookService.GetAllAuthors().ToDisplayVM()
            };
            return View(books);
        }
        public ActionResult AuthorBooks(string author)
        {
            if(author == null || _bookService.GetAllAuthors().Where(a => a.Name == author).SingleOrDefault() == null)
            {
                return HttpNotFound();
            }
            ViewBag.Author = author;
            var books = new BookDisplayViewModel()
            {
                Books = _bookService.GetSpecificAuthorBooks(author).ToDisplayVM()
            };
            return View(books);
        }
        public ActionResult Publishers()
        {
            var books = new PublisherDisplayViewModel()
            {
                Publishers = _bookService.GetAllPublishers().ToDisplayVM()
            };
            return View(books);
        }
        public ActionResult PublisherBooks(string publisher)
        {
            if (publisher == null || _bookService.GetAllPublishers().Where(a => a.Name == publisher).SingleOrDefault() == null)
            {
                return HttpNotFound();
            }
            ViewBag.Publisher = publisher;
            var books = new BookDisplayViewModel()
            {
                Books = _bookService.GetSpecificPublisherBooks(publisher).ToDisplayVM()
            };
            return View(books);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Book(int? id)
        {
            int bookId = id.GetValueOrDefault();
            if (bookId != 0)
            {
                var selected = _bookService.GetBookById(bookId).ToDisplayVM();

                if (selected == null)
                    return HttpNotFound();
                else
                    return View(selected);


            }
            return HttpNotFound();
        }
        [Authorize]
        public ActionResult Account()
        {
            var rentedBooks = new RentedBookViewModel()
            {
                Books = _rentedBookService.GetAllRentedBooks(User.Identity.GetUserId()).ToList()
            };

            return View(rentedBooks);
        }
    }
}