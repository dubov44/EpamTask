using EpamLibrary.Tables.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpamLibrary.Tables.Models
{
    public class Request : AbstractDbObject
    {
        public string ClientName { get; set; }
        public string BookName { get; set; }
        public string ClientProfileId { get; set; }
        public virtual ClientProfile ClientProfile { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
