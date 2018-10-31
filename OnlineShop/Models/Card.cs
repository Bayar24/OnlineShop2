using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Card
    {
        public long CardId { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public int ExpYear { get; set; }
        public byte ExpMonth { get; set; }
        public int CVV { get; set; }
        public int ZipCode { get; set; }
        public byte Status { get; set; }
        public string CardType { get; set; }
        public long CustomerId { get; set; }
        
    }
}