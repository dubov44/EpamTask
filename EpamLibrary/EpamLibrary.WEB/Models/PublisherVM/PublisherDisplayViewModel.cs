using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamLibrary.WEB.Models.PublisherVM
{
    public class PublisherDisplayViewModel
    {
        public IEnumerable<PublisherViewModel> Publishers { get; set; }
    }
}