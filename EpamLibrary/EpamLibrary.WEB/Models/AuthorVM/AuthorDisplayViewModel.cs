using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamLibrary.WEB.Models.AuthorVM
{
    public class AuthorDisplayViewModel
    {
        public IEnumerable<AuthorViewModel> Authors { get; set; }
    }
}