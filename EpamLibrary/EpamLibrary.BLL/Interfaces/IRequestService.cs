using EpamLibrary.Tables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamLibrary.BLL.Interfaces
{
    public interface IRequestService
    {
        IEnumerable<Request> GetAllRequests();
        void RequestBook(int bookId, string userId);
        Request GetRequestById(int id);
        void ConfirmRequest(int id);
    }
}
