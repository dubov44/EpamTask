using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EpamLibrary.WEB.Models
{
    public class BookEditModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Discription { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }
        [Required]
        public string Authors { get; set; }
        [Required]
        public string Genres { get; set; }
        [Required]
        public string Publisher { get; set; }
    }
}