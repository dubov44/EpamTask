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
        /// <summary>
        /// creates new user
        /// </summary>
        Task<OperationDetails> Create(UserDTO userDto);
        /// <summary>
        /// authenticates current user
        /// </summary>
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        /// <summary>
        /// returns list of users with selected role
        /// or just returs all users
        /// </summary>
        IEnumerable<UserDTO> GetUsersByRole(string roleName = null);
        /// <summary>
        /// changes selected user's role to new role
        /// </summary>
        OperationDetails AddToRole(string userName, string roleName);
        /// <summary>
        /// returns selected user's role
        /// </summary>
        string GetUserRole(string userName);
    }
}