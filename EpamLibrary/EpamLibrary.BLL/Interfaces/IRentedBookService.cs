using EpamLibrary.BLL.DTO;
using EpamLibrary.BLL.Infrastructure;
using System.Collections.Generic;

namespace EpamLibrary.BLL.Interfaces
{
    /// <summary>
    /// operations with rented books
    /// </summary>
    public interface IRentedBookService
    {
        /// <summary>
        /// returns all rented books from current user
        /// </summary>
        IEnumerable<RentedBookDTO> GetAllRentedBooks(string userId);
        /// <summary>
        /// checks which books is 'expired' and deletes all books from reading room
        /// </summary>
        void UpdateRent(string userId);
        /// <summary>
        /// returns current user's debt
        /// </summary>
        int GetUserDebt(string userId);
        OperationDetails Remove(int rentedBookId);
    }
}
