using EpamLibrary.Tables.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpamLibrary.Tables.Models
{
    public class RentedBook : AbstractDbObject
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string ClientProfileId { get; set; }
        public virtual ClientProfile ClientProfile { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int Penalty { get; set; }
    }
}
