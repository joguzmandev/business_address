using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Business_address.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Campo {0} requerido")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Campo {0} requerido")]
        public string Sector { get; set; }
        public string HouseNumber { get; set; }
        public string Reference { get; set; }
        public string City { get; set; }

        [ForeignKey("Client")]
        public int ClientID { get; set; }

        public Client Client { get; set; }
    }
}