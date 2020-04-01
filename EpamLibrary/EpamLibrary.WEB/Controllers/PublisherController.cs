using EpamLibrary.BLL.Interfaces;
using EpamLibrary.WEB.Infrastructure.Automapper;
using EpamLibrary.WEB.Models.PublisherVM;
using System.Web.Mvc;

namespace EpamLibrary.WEB.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IBookService _bookService;
        public PublisherController(IBookService bookService)
        {
            _bookService = bookService;
        }
        // GET: Publisher
        public ActionResult All()
        {
            var books = new PublisherDisplayViewModel()
            {
                Publishers = _bookService.GetAllPublishers().ToDisplayVM()
            };
            return View(books);
        }
    }
}