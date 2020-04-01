using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamLibrary.WEB.Models.RentedBookVM
{
    public class RentedBookViewModel
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int BookId { get; set; }
        public string Name { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int Penalty { get; set; }
        public int Debt { get; set; } = 0;
        public bool IsExpired { get; set; }
    }
}