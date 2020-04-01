using EpamLibrary.BLL.Interfaces;
using EpamLibrary.WEB.Infrastructure.Automapper;
using EpamLibrary.WEB.Models;
using EpamLibrary.WEB.Models.RequestVM;
using System.Web.Mvc;

namespace EpamLibrary.WEB.Controllers
{
    [Authorize(Roles = "admin, librarian")]
    public class LibrarianController : Controller
    {
        private readonly IRequestService _requestService;
        public LibrarianController(IRequestService requestService)
        {
            _requestService = requestService;
        }
        public ActionResult Requests()
        {
            var requests = new IndexViewModel<RequestViewModel>()
            {
                Items = _requestService.GetAllRequests().ToDisplayVM()
            };
            return View(requests);
        }
        public ActionResult ConfirmRequest(int? id)
        {
            if (id == null)
                return HttpNotFound();
            return View(_requestService.GetRequestById(id.GetValueOrDefault()).ToDisplayVM());
        }
        public ActionResult ConfirmRequestToReadingRoom(int? id)
        {
            if (id == null)
                return HttpNotFound();
            _requestService.ConfirmRequest(id.GetValueOrDefault(), 1, true);
            return RedirectToAction("Requests");
        }
        [HttpPost]
        public ActionResult ConfirmRequest(RequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                _requestService.ConfirmRequest(model.Id, model.Period);
                return RedirectToAction("Requests");
            }
            return View(model);
        }
    }
}