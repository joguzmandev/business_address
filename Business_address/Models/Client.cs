using System;
using System.Collections.Generic;
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

        [MaxLength(50),Required(ErrorMessage ="Campo {} requerido")]
        public string Name { get; set; }
        [MaxLength(50), Required(ErrorMessage = "Campo {} requerido")]
        public string Surname { get; set; }
        [MaxLength(10)]
        public string Phone { get; set; }
        [DataType(DataType.Date)]
        public DateTime Born { get; set; }
        public Boolean IsActive { get; set; }

        [ForeignKey("Business")]
        public int BusinessID { get; set; }

        public List<Address> Addresses { get; set; }

        public Business Business { get; set; }
    }
}