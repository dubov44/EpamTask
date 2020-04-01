using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EpamLibrary.WEB.Models.RequestVM
{
    public class RequestViewModel
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string ClientName { get; set; }
        public string BookName { get; set; }
        public string ClientProfileId { get; set; }
        public int BookId { get; set; }

        [Required, Range(1, 30), Display(Name = "Days")]
        public int Period { get; set; } = 7;
    }
}