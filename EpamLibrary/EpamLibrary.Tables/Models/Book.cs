using EpamLibrary.Tables.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpamLibrary.Tables.Models
{
    public class Book : AbstractDbObject
    {
        [Required]
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Discription { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
        public Book()
        {
            Authors = new List<Author>();
            Genres = new List<Genre>();
            Requests = new List<Request>();
        }
    }
}
