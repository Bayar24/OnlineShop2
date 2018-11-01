using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrderId { get; set; }
        [Required()]
        public string Status { get; set; }
        [Required()]
        public DateTime OrderDate { get; set; }
        [Required()]
        public string ZipCode { get; set; }
        public int? AddressId { get; set; }
        public virtual Address Address { get; set; }
        public decimal TotalAmount { get; set; }
        public long? CardId { get; set; }
        public virtual Card Card { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        [Required()]
        public long CustomerId { get; set; }
    }
}