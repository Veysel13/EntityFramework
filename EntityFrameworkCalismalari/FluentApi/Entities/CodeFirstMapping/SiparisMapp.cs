using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EntityFrameworkCalismalari.FluentApi.Entities.CodeFirstMapping
{
    public class SiparisMapp:EntityTypeConfiguration<Siparis>
    {
       

        public SiparisMapp()
        {
            this.HasKey(x => x.OrderID);

            this.Property(x => x.OrderID).IsRequired();
            this.Property(x => x.CustomerID).IsFixedLength().HasMaxLength(5);

            this.ToTable("Siparis");

            this.Property(x => x.CustomerID).HasColumnName("CustomerID");
            this.Property(x => x.OrderID).HasColumnName("OrderID");
            this.Property(x => x.OrderDate).HasColumnName("OrderDate");


            //bir muşterinin siparisi olmaya o manada optional yaptık
            //musteirden siparise bir bire  cok ilişkı tanımladık
            //customerıd de foreignkey yaptık
            this.HasOptional(x=>x.Musteri).WithMany(x=>x.Siparis).HasForeignKey(x=>x.CustomerID);
        }

    }
}