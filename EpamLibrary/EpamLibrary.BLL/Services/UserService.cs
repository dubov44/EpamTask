using EpamLibrary.BLL.DTO;
using EpamLibrary.BLL.Infrastructure;
using EpamLibrary.DAL.Entities;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using EpamLibrary.BLL.Interfaces;
using EpamLibrary.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using EpamLibrary.BLL.Infrastructure.Mappers;
using NLog;

namespace EpamLibrary.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        Logger log = LogManager.GetCurrentClassLogger();

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            ApplicationUser user = await _unitOfWork.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                var result = await _unitOfWork.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                await _unitOfWork.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                ClientProfile clientProfile = new ClientProfile { ClientProfileId = user.Id, Name = userDto.Name, Email = userDto.Email };
                _unitOfWork.ClientManager.Create(clientProfile);
                await _unitOfWork.SaveAsync();
                log.Info($"user [{userDto.Name}] was created");
                return new OperationDetails(true, "Register successfull", "");
            }
            return new OperationDetails(false, "User with this email already exists", "Email");
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            ApplicationUser user = await _unitOfWork.UserManager.FindAsync(userDto.Email, userDto.Password);
            if (user != null)
                claim = await _unitOfWork.UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        public IEnumerable<UserDTO> GetUsersByRole(string roleName = null)
        {
            if (roleName == null)
                return _unitOfWork.UserManager.Users.ToDTO();
            var role = _unitOfWork.RoleManager.FindByName(roleName);
            var users = _unitOfWork.UserManager.Users.Where(u => u.Roles.Any(r => r.RoleId == role.Id)).ToDTO();
            if (users.Count() > 0)
                foreach (var user in users)
                {
                    user.Role = roleName;
                }
            return users;
        }

        public OperationDetails AddToRole(string userName, string roleName)
        {
            var user = _unitOfWork.UserManager.FindByName(userName);
            var role = _unitOfWork.RoleManager.FindByName(roleName);
            if (role == null)
                return new OperationDetails(false, $"Role {roleName} does not exist", "");
            if (user == null)
                return new OperationDetails(false, $"User {userName} does not exist", "");

            if (_unitOfWork.UserManager.IsInRole(user.Id, roleName))
                return new OperationDetails(false, $"User {userName} is already {roleName}", "");

            user.Roles.Clear();

            if (_unitOfWork.UserManager.AddToRole(user.Id, roleName).Succeeded)
            {
                _unitOfWork.Save();
                log.Info($"User [{userName}] has been promoted to [{roleName}]");
                return new OperationDetails(true, $"User {userName} is now {roleName}", "");
            }

            return new OperationDetails(false, "ERROR", "");
        }
        public string GetUserRole(string userId)
        {
            var user = _unitOfWork.UserManager.FindById(userId);
            var roles = _unitOfWork.RoleManager.Roles.ToList();

            foreach(var role in roles)
            {
                if(_unitOfWork.UserManager.IsInRole(user.Id, role.Name))
                {
                    return role.Name;
                }
            }
            return "error";
        }
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}