using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EntityFrameworkCalismalari.Entities;

namespace EntityFrameworkCalismalari.Contexts
{
    public class SqlContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

    }
}