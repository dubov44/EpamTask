using EpamLibrary.BLL.Interfaces;
using EpamLibrary.WEB.Infrastructure.Automapper;
using EpamLibrary.WEB.Models;
using EpamLibrary.WEB.Models.GenreVM;
using System.Web.Mvc;

namespace EpamLibrary.WEB.Controllers
{
    public class GenreController : Controller
    {
        private readonly IBookService _bookService;
        public GenreController(IBookService bookService)
        {
            _bookService = bookService;
        }
        // GET: Genre
        public ActionResult All()
        {
            var books = new IndexViewModel<GenreViewModel>()
            {
                Items = _bookService.GetAllGenres().ToDisplayVM()
            };
            return View(books);
        }
    }
}