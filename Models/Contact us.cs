using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Contact_Us.Models
{
    public class Contact_us
    {
        [Required]
        public string Name { get; set; }
        [Phone]
        public int Phone { get; set; }
        [Required]
        public string Message { get; set; }
        [EmailAddress]
        public  string Email { get; set; }

    }
}