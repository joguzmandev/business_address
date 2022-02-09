using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [Required(ErrorMessage ="Campo {0} requerido"),DisplayName("Calle")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Campo {0} requerido"), DisplayName("Sector")]
        public string Sector { get; set; }

        [DisplayName("Número de la Casa")]
        public string HouseNumber { get; set; }

        [DataType(DataType.MultilineText), DisplayName("Referencia")]
        public string Reference { get; set; }

        [DisplayName("Ciudad")]
        public string City { get; set; }

        [ForeignKey("Client"),Required(ErrorMessage = "Campo {0} requerido"), DisplayName("Cliente")]
        public int ClientID { get; set; }

        public Client Client { get; set; }
    }
}