using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpamLibrary.Tables.Models
{
    public class ClientProfile
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string ClientProfileId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public int Debt { get; set; } = 0;

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<RentedBook> RentedBooks { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public ClientProfile()
        {
            RentedBooks = new List<RentedBook>();
            Requests = new List<Request>();
        }
    }
}