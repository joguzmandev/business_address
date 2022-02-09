using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Business_address.Models
{
    public class Business
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50), Required(ErrorMessage = "Campo {0} requerido"), DisplayName("Nombre")]
        public string Name { get; set; }
        [MaxLength(9), Required(ErrorMessage = "Campo {0} requerido"),DisplayName("RNC")]
        public string RNC { get; set; }
        [DisplayName("Teléfono")]
        public string Telefono { get; set; }
        [DisplayName("Descripción")]
        public string Description { get; set; }

        public List<Client> Clients { get; set; }
    }
}