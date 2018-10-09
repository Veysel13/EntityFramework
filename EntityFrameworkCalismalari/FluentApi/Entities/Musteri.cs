using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkCalismalari.FluentApi.Entities
{
    public class Musteri
    {
        public Musteri()
        {
            Siparis = new List<Siparis>();
        }

        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
       
        public List<Siparis> Siparis { get; set; }


      
    }
}