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
        /// <summary>
        /// returns all requests
        /// </summary>
        IEnumerable<RequestDTO> GetAllRequests();
        /// <summary>
        /// creates request for selected book from current user
        /// </summary>
        OperationDetails RequestBook(int bookId, string userId);
        /// <summary>
        /// returns request by id
        /// </summary>
        RequestDTO GetRequestById(int id);
        /// <summary>
        /// creates requested book and adds it to user on selected period
        /// </summary>
        void ConfirmRequest(int id, int period, bool readingRoom = false);
    }
}
