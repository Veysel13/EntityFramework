using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EntityFrameworkCalismalari.Entities
{
    //tablo ismini veriyoruz
    [Table("Customers")]
    public class Customer
        {

            public Customer()
            {
                Orders =new List<Order>();
            }

            //zorunlu alan olarak belirttik
            //oto number olarak identiy oalrak atama default gelir
            //identiy yerine none yazarsam kendim elle vericem demektir
            [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }

            //bu kolonun ısmının ulke olmasını ıstıyorum
            [Column("Ulke")]
        public string Country { get; set; }

            //foreigkey ataması yaptık
            [ForeignKey("CustomerID")]
        public  List<Order> Orders { get; set; }


            //bu kolonun veritabanında olusmanısını ıstemıyorum
            [NotMapped]
            //veri değişirkende bunun değerini al anlamında
            //veri değişebilir
            [ConcurrencyCheck]
            public int UlkeSiparais { get; set; }

    }
}