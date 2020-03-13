using EpamLibrary.Tables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamLibrary.BLL.Interfaces
{
    public interface IRentedBookService
    {
        IEnumerable<RentedBook> GetAllRentedBooks(string userId);
    }
}
