using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Subscription
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required()]
        public decimal Amount { get; set; }
        [Required()]
        public double CompPercentage { get; set; }
        [Required()]
        public double VendorPercentage { get; set; }
        [Required()]
        public double TaxPercentage { get; set; }
        [Required()]
        public DateTime DateCreated { get; set; }
        [Required()]
        public String Status { get; set; }

    }
}