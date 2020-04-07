using EpamLibrary.BLL.DTO;
using EpamLibrary.BLL.Infrastructure;
using EpamLibrary.BLL.Infrastructure.Mappers;
using EpamLibrary.BLL.Interfaces;
using EpamLibrary.DAL.Entities;
using EpamLibrary.DAL.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EpamLibrary.BLL.Services
{
    public class RequestService : IRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        Logger log = LogManager.GetCurrentClassLogger();

        public RequestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<RequestDTO> GetAllRequests()
        {
            return _unitOfWork.RequestRepository.Get().OrderByDescending(b => b.Id).ToDTO();
        }

        public RequestDTO GetRequestById(int id)
        {
            return _unitOfWork.RequestRepository.GetById(id).ToDTO();
        }

        public OperationDetails RequestBook(int bookId, string userId)
        {
            var book = _unitOfWork.BookRepository.GetById(bookId);
            if (book.Quantity <= 0)
                return new OperationDetails(false, "Sorry, this book is out of stock now", "");
            if (book != null)
            {
                var user = _unitOfWork.ClientManager.GetById(userId);
                if (user == null)
                {
                    log.Error($"User [{userId}] not found");
                    return new OperationDetails(false, "User not found", "");
                }
                if(_unitOfWork.RequestRepository.Get(r => r.ClientProfileId == userId && r.BookId == bookId && r.IsDeleted == false).Any())
                    return new OperationDetails(false, "You have already requested this book \n Please, wait for librarian to confirm your request", "");
                if (_unitOfWork.RentedBookRepository.Get(b => b.ClientProfileId == userId && b.BookId == bookId && b.IsDeleted == false).Any())
                    return new OperationDetails(false, "You already have this book on your account \nYou must return it before getting the same one", "");
                var request = new Request() {Book = book,
                    BookName = book.Name,
                    ClientProfile = user, 
                    ClientName = user.Email };
                _unitOfWork.RequestRepository.Create(request);
                book.Requests.Add(request);
                _unitOfWork.BookRepository.Update(book);
                log.Info($"User [{user.Name}] requested book [{book.Name}]");
                return new OperationDetails(true, "", "");
            }
            log.Error($"Book [{bookId}] not found");
            return new OperationDetails(false, "Book not found", "");
        }

        public void ConfirmRequest(int id, int period, bool readingRoom = false)
        {
            var requestedBook = _unitOfWork.RequestRepository.GetById(id);
            if (requestedBook != null)
            {
                var rentedBook = new RentedBook()
                {
                    BookId = requestedBook.BookId,
                    Name = requestedBook.BookName,
                    ClientProfile = _unitOfWork.ClientManager.GetById(requestedBook.ClientProfileId),
                    RentDate = DateTime.Now,
                    ReturnDate = DateTime.Now.AddDays(period),
                    Penalty = 4,
                    ReadingRoom = readingRoom
                };
                _unitOfWork.RentedBookRepository.Create(rentedBook);
                requestedBook.IsDeleted = true;
                _unitOfWork.RequestRepository.Update(requestedBook);
                var book = _unitOfWork.BookRepository.GetById(requestedBook.BookId);
                book.Quantity -= 1;
                _unitOfWork.BookRepository.Update(book);
                log.Info($"User [{requestedBook.ClientName}] got book [{requestedBook.BookName}]");
            }
            log.Error($"Request [{id}] not found");
        }
    }
}
