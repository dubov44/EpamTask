using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EpamLibrary.WEB.Models.BookVM
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Discription { get; set; }
        public string ImagePath { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }
        public ICollection<string> Authors { get; set; }
        public ICollection<string> Genres { get; set; }
        public string Publisher { get; set; }
    }
}