using System;
using System.Collections.Generic;

namespace EpamLibrary.BLL.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string Name { get; set; }
        public string Discription { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }
        public DateTime PublicationDate { get; set; }
        public ICollection<string> Authors { get; set; }
        public ICollection<string> Genres { get; set; }
        public string Publisher { get; set; }
    }
}
