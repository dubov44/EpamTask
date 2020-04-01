using EpamLibrary.BLL.Interfaces;
using EpamLibrary.WEB.Infrastructure.Automapper;
using EpamLibrary.WEB.Models.AuthorVM;
using System.Web.Mvc;

namespace EpamLibrary.WEB.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IBookService _bookService;

        // GET: Author
        public AuthorController(IBookService bookService)
        {
            _bookService = bookService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult All()
        {
            var books = new AuthorDisplayViewModel()
            {
                Authors = _bookService.GetAllAuthors().ToDisplayVM()
            };
            return View(books);
        }
    }
}