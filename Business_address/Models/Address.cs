﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Business_address.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Street { get; set; }
        public string Sector { get; set; }
        public string HouseNumber { get; set; }
        public string Reference { get; set; }
        public string City { get; set; }
    }
}