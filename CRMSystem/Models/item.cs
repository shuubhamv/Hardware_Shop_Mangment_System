using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMSystem.Models
{
    public class item
    {
        [Key]
        public int itemid { get; set; }

        public string itemName { get; set; }


        [Required]
        public string category { get; set; }

        public string manufacturer { get; set; }

        public int quntity { get; set; }
    }
}