using EpamLibrary.BLL.DTO;
using EpamLibrary.BLL.Infrastructure;
using EpamLibrary.BLL.Infrastructure.Mappers;
using EpamLibrary.BLL.Interfaces;
using EpamLibrary.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EpamLibrary.BLL.Services
{
    public class RentedBookService : IRentedBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RentedBookService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// returns all rented books from current user
        /// </summary>
        public IEnumerable<RentedBookDTO> GetAllRentedBooks(string userId)
        {
            var rentedBooks = _unitOfWork.RentedBookRepository.Get(b => b.ClientProfileId == userId).OrderByDescending(b => b.Id).ToDTO();
            UpdateRent(userId);
            return rentedBooks;
        }

        /// <summary>
        /// checks which books is 'expired' and deletes all books from reading room
        /// </summary>
        public void UpdateRent(string userId)
        {
            var user = _unitOfWork.ClientManager.GetById(userId);
            user.Debt = 0;
            foreach (var book in user.RentedBooks)
            {
                if (DateTime.Now > book.ReturnDate && book.ReadingRoom == true)
                {
                    Remove(book.Id);
                }
                else if(DateTime.Now > book.ReturnDate)
                {
                    book.IsExpired = true;
                    user.Debt += book.Penalty * int.Parse((DateTime.Now - book.ReturnDate).Days.ToString());
                }
            }
            _unitOfWork.ClientManager.Update(user);
        }

        /// <summary>
        /// returns current user's debt
        /// </summary>
        public int GetUserDebt(string userId)
        {
            return _unitOfWork.ClientManager.GetById(userId).Debt;
        }
        public OperationDetails Remove(int rentedBookId)
        {
            var rentedBook = _unitOfWork.RentedBookRepository.GetById(rentedBookId);
            if (rentedBook == null)
                return new OperationDetails(false, $"Book {rentedBookId} not found", "");
            _unitOfWork.RentedBookRepository.Delete(rentedBookId);
            var book = _unitOfWork.BookRepository.GetById(rentedBook.BookId);
            book.Quantity += 1;
            _unitOfWork.BookRepository.Update(book);
            _unitOfWork.Save();
            return new OperationDetails(true, $"Book [{rentedBook.Name}] has been deleted", "");
        }
    }
}
