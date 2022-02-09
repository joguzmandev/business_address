using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Business_address.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50),Required(ErrorMessage ="Campo {0} requerido"),DisplayName("Nombre")]
        public string Name { get; set; }
        [MaxLength(50), Required(ErrorMessage = "Campo {0} requerido"), DisplayName("Apellido(s)")]
        public string Surname { get; set; }
        [MaxLength(10), DisplayName("Teléfono")]
        public string Phone { get; set; }
        [DataType(DataType.Date), DisplayName("Fecha Nacimiento"), Required(ErrorMessage = "Campo {0} requerido")]
        public DateTime Born { get; set; }
        [DisplayName("Activo")]
        public Boolean IsActive { get; set; }

        [ForeignKey("Business"), Required(ErrorMessage = "Campo {0} requerido"), DisplayName("Empresa")]
        public int BusinessID { get; set; }

        public List<Address> Addresses { get; set; }

        public Business Business { get; set; }
    }
}