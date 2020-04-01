using EpamLibrary.WEB.Models.RentedBookVM;
using EpamLibrary.WEB.Models.RequestVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamLibrary.WEB.Models.UserVM
{
    public class AccountViewModel
    {
        public IEnumerable<RentedBookViewModel> RentedBooks { get; set; }
        public IEnumerable<RequestViewModel> Requests { get; set; }
    }
}