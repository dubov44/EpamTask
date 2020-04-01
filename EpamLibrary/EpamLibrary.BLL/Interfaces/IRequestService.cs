using EpamLibrary.BLL.DTO;
using EpamLibrary.BLL.Infrastructure;
using System.Collections.Generic;

namespace EpamLibrary.BLL.Interfaces
{
    /// <summary>
    /// operations with requests
    /// </summary>
    public interface IRequestService
    {
        IEnumerable<RequestDTO> GetAllRequests();
        OperationDetails RequestBook(int bookId, string userId);
        RequestDTO GetRequestById(int id);
        void ConfirmRequest(int id, int period, bool readingRoom = false);
    }
}
