using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EpamLibrary.WEB.Models.BookVM
{
    public class BookEditModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, Range(0, 100)]
        public int Quantity { get; set; }
        [Required]
        public string Discription { get; set; }
        [DataType(DataType.Date), Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime PublicationDate { get; set; }
        [Required]
        public string Authors { get; set; }
        [Required]
        public string Genres { get; set; }
        [Required]
        public string Publisher { get; set; }
        public string ImagePath { get; set; } = "http://placehold.it/225x337";
    }
}