using EpamLibrary.BLL.Interfaces;
using EpamLibrary.DAL.Interfaces;
using EpamLibrary.Tables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamLibrary.BLL.Services
{
    public class RequestService : IRequestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RequestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Request> GetAllRequests()
        {
            var requests = _unitOfWork.RequestRepository.Get().OrderByDescending(b => b.Id);
            return requests;
        }
        public Request GetRequestById(int id)
        {
            return _unitOfWork.RequestRepository.GetById(id);
        }
        public void RequestBook(int bookId, string userId)
        {
            var book = _unitOfWork.BookRepository.GetById(bookId);
            if (book != null)
            {
                var client = _unitOfWork.ClientManager.GetById(userId);
                var request = new Request() {Book = book,
                    BookName = book.Name,
                    ClientProfile = client, 
                    ClientName = client.Email };
                _unitOfWork.RequestRepository.Create(request);
                book.Requests.Add(request);
                _unitOfWork.BookRepository.Update(book);
            }
        }
        public void ConfirmRequest(int id)
        {
            var request = _unitOfWork.RequestRepository.GetById(id);
            if (request != null)
            {
                var rentedBook = new RentedBook()
                {
                    BookId = request.BookId,
                    Name = request.BookName,
                    ClientProfile = _unitOfWork.ClientManager.GetById(request.ClientProfileId),
                    RentDate = DateTime.Now,
                    ReturnDate = DateTime.Now.AddDays(1),
                    Penalty = 4
                };
                _unitOfWork.RentedBookRepository.Create(rentedBook);
                request.IsDeleted = true;
                _unitOfWork.RequestRepository.Update(request);
                var book = _unitOfWork.BookRepository.GetById(request.BookId);
                book.Quantity -= 1;
                _unitOfWork.BookRepository.Update(book);
            }
        }
    }
}
