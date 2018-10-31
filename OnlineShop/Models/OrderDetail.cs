using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class OrderDetail
    {
        public long OrderDetailId { get; set; }
        public long OrderId { get; set; }
        public Product Product { get; set; }
    }
}