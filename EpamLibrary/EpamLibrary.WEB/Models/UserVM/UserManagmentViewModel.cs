using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamLibrary.WEB.Models.UserVM
{
    public class UserManagmentViewModel
    {
        public IEnumerable<UserViewModel> Admins { get; set; }
        public IEnumerable<UserViewModel> Librarians { get; set; }
        public IEnumerable<UserViewModel> Users { get; set; }
        public IEnumerable<UserViewModel> Banned { get; set; }
        public UserManagmentViewModel()
        {
            Admins = new List<UserViewModel>();
            Librarians = new List<UserViewModel>();
            Users = new List<UserViewModel>();
            Banned = new List<UserViewModel>();
        }
    }
}