using Business_address.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Business_address.Db
{
    public class BAContextDB : DbContext
    {
        public BAContextDB():base(nameOrConnectionString: "BussinessAddressConn")
        {

        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Business> Businesses { get; set; }
    }
}