using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Business_address.Models
{
    public class Business
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string RNC { get; set; }
        public string Telefono { get; set; }
        public string Description { get; set; }

        public List<Client> Clients { get; set; }
    }
}