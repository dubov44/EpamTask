using EpamLibrary.BLL.Infrastructure;
using EpamLibrary.BLL.Interfaces;
using EpamLibrary.Tables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using EpamLibrary.WEB.Models;
using EpamLibrary.BLL.DTO;
using EpamLibrary.WEB.Infrastructure.Automapper;

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
        [Authorize(Roles = "admin")]
        public ActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(BookEditModel model)
        {
            if (ModelState.IsValid)
            {
                _bookService.AddBook(model.ToDTO());
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        [Authorize]
        public ActionResult RentBook(int id)
        {
            _requestService.RequestBook(id, User.Identity.GetUserId());

            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();
            return View(_bookService.GetBookById(id.GetValueOrDefault()).ToEditModel());
        }
        [HttpPost]
        public ActionResult Edit(BookEditModel model)
        {
            if (ModelState.IsValid)
            {
                _bookService.EditBook(model.ToDTO());
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}