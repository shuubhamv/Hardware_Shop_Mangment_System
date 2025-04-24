using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CRMSystem.Models
{
    public class CRMContext : DbContext
    {
        public CRMContext() : base("name=CRMDBConnection") { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<item> item { get; set; }

        public DbSet<bill> bill { get; set; }

    }
}