using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamLibrary.WEB.Models.BookVM
{
    public class BookDisplayViewModel
    {
        public IEnumerable<BookViewModel> Books { get; set; }
    }
}