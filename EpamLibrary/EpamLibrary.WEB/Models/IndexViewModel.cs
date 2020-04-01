using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamLibrary.WEB.Models
{
    public class IndexViewModel<T>
        where T : class
    {
        public IEnumerable<T> Items { get; set; }
        public Pager Pager { get; set; }
        public T Model { get; set; }
    }
}