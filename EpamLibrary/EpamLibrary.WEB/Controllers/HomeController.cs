using EpamLibrary.BLL.Interfaces;
using EpamLibrary.WEB.Infrastructure.Automapper;
using EpamLibrary.WEB.Models;
using EpamLibrary.WEB.Models.RentedBookVM;
using EpamLibrary.WEB.Models.UserVM;
using Microsoft.AspNet.Identity;
using NLog;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpamLibrary.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IRentedBookService _rentedBookService;
        private readonly IRequestService _requestService;
        public HomeController(IBookService bookService, 
            IRentedBookService rentedBookService, 
            IRequestService requestService)
        {
            _bookService = bookService;
            _rentedBookService = rentedBookService;
            _requestService = requestService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize(Roles = "user, admin, librarian")]
        public ActionResult Account()
        {
            if (TempData["details"] != null)
                ViewBag.Details = TempData["details"] as OperationDetailsViewModel;
            var rentedBooks = new AccountViewModel()
            {
                RentedBooks = _rentedBookService.GetAllRentedBooks(User.Identity.GetUserId()).ToDisplayVM(),
                Requests = _requestService.GetAllRequests().Where(r => r.ClientProfileId == User.Identity.GetUserId() && r.IsDeleted == false).ToDisplayVM()
            };
            ViewBag.Debt = _rentedBookService.GetUserDebt(User.Identity.GetUserId());
            ViewBag.Name = User.Identity.Name;
            return View(rentedBooks);
        }
        [Authorize(Roles = "user, admin, librarian")]
        public ActionResult RemoveBook(int? id)
        {
            if (id == null)
                return HttpNotFound();
            var details = _rentedBookService.Remove(id.GetValueOrDefault()).ToDisplayVM();
            TempData["details"] = details;
            TempData.Keep("details");
            return RedirectToAction("Account", "Home");
        }
    }
}