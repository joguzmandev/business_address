using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Business_address.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public DateTime Born { get; set; }
        public Boolean IsActive { get; set; }

        public List<Address> Addresses { get; set; }

        public Business Business { get; set; }
    }
}