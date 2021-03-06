﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }
        [Required()]
        public string Street { get; set; }
        [Required()]
        public string City { get; set; }
        [Required()]
        public string State { get; set; }
        [Required()]
        public string ZipCode { get; set; }
        [Required()]
        public string Country { get; set; }
}
}