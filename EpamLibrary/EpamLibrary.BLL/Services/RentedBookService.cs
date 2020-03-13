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
    public class RentedBookService : IRentedBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RentedBookService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<RentedBook> GetAllRentedBooks(string userId)
        {
            var rentedBooks = _unitOfWork.RentedBookRepository.Get(b => b.ClientProfileId == userId).OrderByDescending(b => b.Id);
            var user = _unitOfWork.ClientManager.GetById(userId);
            foreach(var book in rentedBooks)
            {
                if (DateTime.Now > book.ReturnDate)
                    user.Debt += book.Penalty * Int32.Parse((book.ReturnDate - DateTime.Now).Days.ToString());
            }
            _unitOfWork.ClientManager.Update(user);
            return rentedBooks;
        }
    }
}
