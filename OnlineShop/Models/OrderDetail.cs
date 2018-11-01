using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class OrderDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrderDetailId { get; set; }
        [Required()]
        public long OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        [Required()]
        public int Quantity { get; set; }
        public long ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}