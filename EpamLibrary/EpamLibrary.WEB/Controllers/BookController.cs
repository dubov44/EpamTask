using EpamLibrary.BLL.Interfaces;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using EpamLibrary.WEB.Infrastructure.Automapper;
using EpamLibrary.WEB.Models.BookVM;
using System.Web.Routing;
using EpamLibrary.WEB.Models;
using System;
using System.Linq;
using System.Web;
using System.IO;
using NLog;

namespace EpamLibrary.WEB.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IRequestService _requestService;
        public BookController(IBookService bookService,
            IRequestService requestService)
        {
            _bookService = bookService;
            _requestService = requestService;
        }
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
        public ActionResult All(int page = 1, string search = null, DateTime? start = null, DateTime? end = null)
        {
            var pager = new Pager(_bookService.GetAllBooks(search, start, end).Count(), page, 6, 3);
            var books = new IndexViewModel<BookViewModel>()
            {
                Items = _bookService.GetAllBooks(search, start, end).Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToDisplayVM(),
                Pager = pager,
                Model = new BookViewModel()
            };
            return View(books);
        }
        public ActionResult Author(string name)
        {
            if (name == null || _bookService.GetAllAuthors().Where(a => a.Name == name).SingleOrDefault() == null)
            {
                return HttpNotFound();
            }
            ViewBag.Author = name;
            var books = new BookDisplayViewModel()
            {
                Books = _bookService.GetSpecificAuthorBooks(name).ToDisplayVM()
            };
            return View(books);
        }
        public ActionResult Genre(string name)
        {
            if (name == null || _bookService.GetAllGenres().Where(a => a.Name == name).SingleOrDefault() == null)
            {
                return HttpNotFound();
            }
            ViewBag.Genre = name;
            var books = new BookDisplayViewModel()
            {
                Books = _bookService.GetSpecificGenreBooks(name).ToDisplayVM()
            };
            return View(books);
        }
        public ActionResult Publisher(string name)
        {
            if (name == null || _bookService.GetAllPublishers().Where(a => a.Name == name).SingleOrDefault() == null)
            {
                return HttpNotFound();
            }
            ViewBag.Publisher = name;
            var books = new BookDisplayViewModel()
            {
                Books = _bookService.GetSpecificPublisherBooks(name).ToDisplayVM()
            };
            return View(books);
        }
        public ActionResult Details(int? id)
        {
            if (TempData["details"] != null)
                ViewBag.Details = TempData["details"] as OperationDetailsViewModel;

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
        [Authorize(Roles = "admin")]
        public ActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(BookEditModel model, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if(Image != null)
                {
                    var fileName = Path.GetFileName(Image.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/images"), fileName);
                    Image.SaveAs(path);
                    model.ImagePath = "/Content/images/" + Image.FileName;
                }
                _bookService.AddBook(model.ToDTO());
                return RedirectToAction("All", "Book");
            }
            return View(model);
        }
        [Authorize(Roles = "user, admin, librarian")]
        public ActionResult RentBook(int id)
        {
            var details = _requestService.RequestBook(id, User.Identity.GetUserId()).ToDisplayVM();
            if (details.Succedeed == true)
                return RedirectToAction("SuccessRent");
            TempData["details"] = details;
            TempData.Keep("details");
            return RedirectToAction("Details", "Book", new { id = id});
        }
        [Authorize(Roles = "user, admin, librarian")]
        public ActionResult SuccessRent()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();
            return View(_bookService.GetBookById(id.GetValueOrDefault()).ToEditModel());
        }
        [HttpPost]
        public ActionResult Edit(BookEditModel model, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    var fileName = Path.GetFileName(Image.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/images"), fileName);
                    Image.SaveAs(path);
                    model.ImagePath = "/Content/images/" + Image.FileName;
                }
                _bookService.EditBook(model.ToDTO());
                return RedirectToAction("All", "Book");
            }
            return View(model);
        }
    }
}