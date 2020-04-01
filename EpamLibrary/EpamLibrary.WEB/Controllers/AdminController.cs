using EpamLibrary.BLL.Infrastructure;
using EpamLibrary.BLL.Interfaces;
using EpamLibrary.WEB.Infrastructure.Automapper;
using EpamLibrary.WEB.Models;
using EpamLibrary.WEB.Models.UserVM;
using System.Web.Mvc;
using System.Web.Routing;

namespace EpamLibrary.WEB.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IRequestService _requestService;
        private readonly IUserService _userService;
        public AdminController(IBookService bookService,
            IRequestService requestService, 
            IUserService userService)
        {
            _bookService = bookService;
            _requestService = requestService;
            _userService = userService;
        }
        public ActionResult UpdradeToLibrarian(string name)
        {
            TempData["details"] = _userService.AddToRole(name, "librarian").ToDisplayVM();
            TempData.Keep("details");
            return RedirectToAction("UserManagment");
        }
        public ActionResult UpdradeToUser(string name)
        {
            TempData["details"] = _userService.AddToRole(name, "user").ToDisplayVM();
            TempData.Keep("details");
            return RedirectToAction("UserManagment");
        }
        public ActionResult BanUser(string name)
        {
            TempData["details"] = _userService.AddToRole(name, "banned").ToDisplayVM();
            TempData.Keep("details");
            return RedirectToAction("UserManagment");
        }
        public ActionResult UserManagment()
        {
            if (TempData["details"] != null)
                ViewBag.Details = TempData["details"] as OperationDetailsViewModel;
            return View(new UserManagmentViewModel()
            {
                Admins = _userService.GetUsersByRole("admin").ToDisplayVM(), //admins
                Librarians = _userService.GetUsersByRole("librarian").ToDisplayVM(), //librarians
                Users = _userService.GetUsersByRole("user").ToDisplayVM(), //users
                Banned = _userService.GetUsersByRole("banned").ToDisplayVM() //users
            });
        }
    }
}