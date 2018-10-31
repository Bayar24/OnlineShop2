using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Order
    {
        public long OrderId { get; set; }
        public byte Status { get; set; }
        public DateTime OrderDate { get; set; }
        public int AddressId { get; set; }
        public decimal TotalAmount { get; set; }
        public long CardId { get; set; }
        public virtual Card Card { get; set; }
        public long CustomerId { get; set; }
    }
}