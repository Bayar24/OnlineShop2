using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Card
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CardId { get; set; }
        [Required()]
        public string CardNumber { get; set; }
        [Required()]
        public string CardHolderName { get; set; }
        [Required()]
        public int ExpYear { get; set; }
        [Required()]
        public byte ExpMonth { get; set; }
        [Required()]
        public int CVV { get; set; }
        [Required()]
        public int ZipCode { get; set; }
        [Required()]
        public string CardType { get; set; }
        [Required()]
        public long CustomerId { get; set; }
    }
}