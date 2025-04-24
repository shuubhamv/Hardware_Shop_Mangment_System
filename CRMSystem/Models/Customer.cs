using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;


namespace CRMSystem.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Email Id")]
        public string ContactInfo { get; set; }

        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; }

        [Display(Name = "Item Purchesed")]
        [Required]
        public string itempurchesed { get; set; }

        public int quntety { get; set; }
        public int ammount { get; set; }
    }
}