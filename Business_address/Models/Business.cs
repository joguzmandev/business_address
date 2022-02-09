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
        [MaxLength(9,ErrorMessage ="El campo {0} debe contener 9 números"), Required(ErrorMessage = "Campo {0} requerido"),DisplayName("RNC")]
        public string RNC { get; set; }
        [DisplayName("Teléfono")]
        public string Telefono { get; set; }
        [DisplayName("Descripción"),DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public List<Client> Clients { get; set; }
    }
}