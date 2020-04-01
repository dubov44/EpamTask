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
        IEnumerable<RentedBookDTO> GetAllRentedBooks(string userId);
        void UpdateRent(string userId);
        int GetUserDebt(string userId);
        OperationDetails Remove(int rentedBookId);
    }
}
