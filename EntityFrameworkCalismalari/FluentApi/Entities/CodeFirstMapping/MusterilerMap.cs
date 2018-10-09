using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using EntityFrameworkCalismalari.Controllers;
using Microsoft.Ajax.Utilities;

namespace EntityFrameworkCalismalari.FluentApi.Entities.CodeFirstMapping
{
    public class MusterilerMap:EntityTypeConfiguration<Musteri>
    {
        public MusterilerMap()
        {
            this.HasKey(x=>x.CustomerID);

            this.Property(x => x.CustomerID).IsRequired().HasMaxLength(5);

            this.Property(x => x.CompanyName).IsRequired().HasMaxLength(40);

            this.Property(x => x.City).HasMaxLength(15);

            this.Property(x => x.ContactName).HasMaxLength(30);

            this.Property(x => x.Country).HasMaxLength(15);



            this.ToTable("Customers");



            this.Property(x => x.CustomerID).HasColumnName("CustomerId");
            this.Property(x => x.Country).HasColumnName("Country");
            this.Property(x => x.ContactName).HasColumnName("ContactName");
            this.Property(x => x.CompanyName).HasColumnName("CompanyName");
            this.Property(x => x.City).HasColumnName("City");
        }
    }
}