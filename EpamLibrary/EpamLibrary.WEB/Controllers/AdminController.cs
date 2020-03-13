using EpamLibrary.BLL.Interfaces;
using EpamLibrary.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpamLibrary.WEB.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IRequestService _requestService;
        public AdminController(IBookService bookService,
            IRequestService requestService)
        {
            _bookService = bookService;
            _requestService = requestService;
        }
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles ="admin")]
        public ActionResult Panel()
        {
            var requests = new RequestViewModel()
            {
                Requests = _requestService.GetAllRequests().ToList()
            };
            return View(requests);
        }
        public ActionResult Confirm(int id)
        {
            _requestService.ConfirmRequest(id);
            return RedirectToAction("Panel");
        }
    }
}