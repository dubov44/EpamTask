using EpamLibrary.Tables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamLibrary.WEB.Models
{
    public class RentedBookViewModel
    {
        public IEnumerable<RentedBook> Books { get; set; }
    }
}