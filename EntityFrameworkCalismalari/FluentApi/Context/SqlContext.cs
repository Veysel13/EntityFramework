using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EntityFrameworkCalismalari.Entities;
using EntityFrameworkCalismalari.FluentApi.Entities;
using EntityFrameworkCalismalari.FluentApi.Entities.CodeFirstMapping;

namespace EntityFrameworkCalismalari.FluentApi.Context
{
    public class SqlContext:DbContext
    {
        //gerkli connection strıngı yaz
        //context adı burada yazdıgımız base sınıfttakı adı
        public SqlContext():base("Name=ContextConnectionString")
        {
            
        }

        public DbSet<Musteri> Musteri { set; get; }
        public DbSet<Siparis> Siparis { set; get; }


        //yazdııgımız mappinglerin uygulanması  için bu rada bunları aktif etmemiz gerekiyor
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MusterilerMap());
            modelBuilder.Configurations.Add(new SiparisMapp());
        }
    }
}