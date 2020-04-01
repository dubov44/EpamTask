using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using EpamLibrary.BLL.DTO;
using EpamLibrary.BLL.Infrastructure;

namespace EpamLibrary.BLL.Interfaces
{
    /// <summary>
    /// operations with users
    /// </summary>
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        IEnumerable<UserDTO> GetUsersByRole(string roleName = null);
        OperationDetails AddToRole(string userName, string roleName);
        string GetUserRole(string userName);
    }
}